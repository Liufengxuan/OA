using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Common;

namespace OA.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ActiveUserInfo()
        {    
            string userInfoSID = Request.Cookies["userInfoSID"].Value;
            Model.UserInfo userInfo =Common.SerializeHelper.DeserializeToObject<Model.UserInfo>( MemcacheHelper.Get(userInfoSID).ToString());
            userInfo.UPwd = "";
            return Content(SerializeHelper.SerializeToString(new {ui=userInfo}));          
        }
    }
}