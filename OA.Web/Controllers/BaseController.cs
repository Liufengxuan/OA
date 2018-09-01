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
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}


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