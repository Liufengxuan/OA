using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class UserInfoController : Controller
    {
        IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
            var a=userInfoService.LoadEntities(u => u.ID == 39);
            UserInfo user = new UserInfo();
            user = a.FirstOrDefault<UserInfo>();
            int ca = 1;
            return View();
        }
    }
}