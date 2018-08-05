using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using ServiceFactory;
=======
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89

namespace OA.Web.Controllers
{
    public class UserInfoController : Controller
    {
<<<<<<< HEAD
         IBLL.IUserInfoService userInfoService = SevSession.GetUserInfoService();
        IBLL.IRoleInfoService roleInfoService = SevSession.GetRoleInfoService();
       
        // GET: UserInfo
        public ActionResult Index()
        {
            RoleInfo role= roleInfoService.LoadEntities(r => r.ID == 2).FirstOrDefault();
=======
        IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
            var a=userInfoService.LoadEntities(u => u.ID == 39);
            UserInfo user = new UserInfo();
            user = a.FirstOrDefault<UserInfo>();
            int ca = 1;
            return View();
        }
    }
}