using OA.Common;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class BaseController : Controller
    {
        IBLL.IUserInfoService UserInfoService = ServiceFactory.SevSession.GetUserInfoService();
        IBLL.IRoleInfoService roleInfoService = ServiceFactory.SevSession.GetRoleInfoService();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie httpCookie= Request.Cookies.Get("userInfoSID");
            bool idIsPass = false;
            UserInfo userInfo = null;
            //账号验证    begin
            if (httpCookie != null)
            {               
                string userInfoSID = httpCookie.Value;
                object obj=  MemcacheHelper.Get(userInfoSID);
                if (obj != null)
                {
                    userInfo = SerializeHelper.DeserializeToObject<UserInfo>(obj.ToString());
                    ////查看该用户有没有角色、并获取角色。
                    //roleInfo = UserInfoService.LoadEntities(u => u.ID == userInfo.ID && u.UPwd == userInfo.UPwd).FirstOrDefault().RoleInfo.FirstOrDefault();
                    if (userInfo != null)
                    {
                        idIsPass = true;
                    }
                }
            }
            // //账号验证 end

            if (idIsPass)  //账号验证通过。
            {
                string url = Request.Url.AbsolutePath.ToLower();
                string method = Request.HttpMethod;
                string controllerName = RouteData.Values["controller"].ToString().ToLower();

                var query = UserInfoService.LoadEntities(u => u.ID == userInfo.ID && u.UPwd == userInfo.UPwd).FirstOrDefault().RoleInfo;

                int count = (from u in query
                             from a in u.ActionInfo
                             where /*a.HttpMethod == method&&*/a.ControllerName==controllerName //a.Url == url 
                             select a).Count();
                if (count > 0)
                {
                    return;
                }
                else
                {
                    filterContext.Result = Redirect(@"/static/Error/nopermission.html");
                    return;
                }
            }
            else           //账号验证未通过。
            {
                filterContext.Result = Redirect("/Login/Index");
                return;
            }

            




            // base.OnActionExecuting(filterContext);
            //filterContext.Result = Redirect("/Login/Index");
        }


        protected Models.WeatherForm GetWeather()
        {
            cn.com.webxml.www.WeatherWebService weather = new cn.com.webxml.www.WeatherWebService();
            string[] rst =weather.getWeatherbyCityName("济南");
            Models.WeatherForm weatherForm = new Models.WeatherForm();
            string[] text ={
                 rst[6],
                 rst[10],
                 rst[7],
                 rst[5]
            };
            string[] city = {
                rst[0],
                rst[1]
            };
            string[] icon = {
                rst[8],
                rst[9]

            };
            weatherForm.Text = text;
            weatherForm.City = city;
            weatherForm.Icon = icon;
            weatherForm.Date = rst[4];
            return weatherForm;
        }

        protected UserInfo GetActiveUserInfo()
        {
            string userInfoSID = Request.Cookies["userInfoSID"].Value;
            Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.GetAndAddMinutes(userInfoSID,20).ToString());
            userInfo.UPwd = "";
            return userInfo;
        }
    }
}