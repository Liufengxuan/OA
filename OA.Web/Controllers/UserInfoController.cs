using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using ServiceFactory;
=======
<<<<<<< HEAD
using ServiceFactory;
=======
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64

namespace OA.Web.Controllers
{
    public class UserInfoController : Controller
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
         IBLL.IUserInfoService userInfoService = SevSession.GetUserInfoService();
        IBLL.IRoleInfoService roleInfoService = SevSession.GetRoleInfoService();
       
        // GET: UserInfo
        public ActionResult Index()
        {
            RoleInfo role= roleInfoService.LoadEntities(r => r.ID == 2).FirstOrDefault();
<<<<<<< HEAD
=======
=======
        IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
            var a=userInfoService.LoadEntities(u => u.ID == 39);
            UserInfo user = new UserInfo();
            user = a.FirstOrDefault<UserInfo>();
            int ca = 1;
            return View();
        }
    }
}