using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Common;
using OA.Model;
using ServiceFactory;

namespace OA.Web.Controllers
{
    public class LoginController : Controller
    {
        IBLL.IUserInfoService userInfoService = SevSession.GetUserInfoService();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            HttpCookie httpCookie = Request.Cookies.Get("userInfo");
            UserInfo userInfo;
            if (httpCookie != null)
            {
                userInfo = SerializeHelper.DeserializeToObject<UserInfo>(httpCookie.Value);
                userInfo = userInfoService.LoadEntities(u => (u.ID == userInfo.ID || u.UName == userInfo.UName) && u.UPwd == userInfo.UPwd).FirstOrDefault();
                string userInfoSID = MemcacheHelper.Set(SerializeHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));
                Response.Cookies["userInfoSID"].Value = userInfoSID;
              //  Response.Cookies["userInfoSID"].Expires = DateTime.Now.AddDays(1);
                return Redirect("/Home/Index");
            }
            return View();
          
        }


        [HttpPost]
        public ActionResult UserLogin(Models.LoginForm from)
        {
            string vcodeSID =Request.Cookies["vCodeSID"].Value.ToString();
            Response.Cookies.Remove("vCodeSID");
            //获取正确验证码
            string vode = MemcacheHelper.Get(vcodeSID).ToString();
            //根据用户名取得用户信息；
            int id = 0;
            if ((from.code == null || from.code == "")||from.code.Trim()!=vode)
            {
                return Content("no:验证码错误！");
            }

            Model.UserInfo userInfo = userInfoService.LoadEntities(u => u.UName == from.user).FirstOrDefault();
            if (userInfo==null)
            {
                if (int.TryParse(from.user, out id))
                {
                    userInfo = userInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
                    if (userInfo == null)
                    {
                        return Content("no:用户名错误");
                    }
                }
            }
            if (from.pwd != userInfo.UPwd)
            {
                return Content("no:密码错误");
            }
            if (from.checkpwd != null)
            {
                Response.Cookies["userInfo"].Value = SerializeHelper.SerializeToString(userInfo);//登陆成功将userinfo写入cookies
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(1);
            }
            else {
                Response.Cookies.Remove("userInfo");
            }
            string userInfoSID= MemcacheHelper.Set(SerializeHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));
            Response.Cookies["userInfoSID"].Value = userInfoSID;
           // Response.Cookies["userInfoSID"].Expires = DateTime.Now.AddDays(1);
            return Content("ok:登陆成功");
        }

        [HttpGet]
        public ActionResult GetVCode()
        {
            ValidateCode vliateCode = new ValidateCode();
            string code = vliateCode.CreateValidateCode(4);//产生验证码
            string sId= MemcacheHelper.Set(code, DateTime.Now.AddMinutes(20));
            Response.Cookies["vCodeSID"].Value = sId;
            byte[] buffer = vliateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }

        
    }
}