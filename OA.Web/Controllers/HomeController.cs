using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Common;

namespace OA.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ActiveUserInfo()
        {
            Model.UserInfo userInfo = GetActiveUserInfo();
            userInfo.UPwd = "";
            return Content(SerializeHelper.SerializeToString(new {ui=userInfo}));          
        }

        public ActionResult Logout()
        {
            Response.Cookies["userInfoSID"].Expires = DateTime.Now.AddDays(-2);
            Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-2);
            return Redirect("/Login/Index");
        }
    }
}