using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceFactory;

namespace OA.Web.Controllers
{
    public class UserInfoController : BaseController
    {
         IBLL.IUserInfoService userInfoService = SevSession.GetUserInfoService();
         IBLL.IRoleInfoService roleInfoService = SevSession.GetRoleInfoService();
       
        // GET: UserInfo
        public ActionResult Index()//测试
        {
            RoleInfo role= roleInfoService.LoadEntities(r => r.ID == 2).FirstOrDefault();
            var a=userInfoService.LoadEntities(u => u.ID == 39);
            UserInfo user = new UserInfo();
            user = a.FirstOrDefault<UserInfo>();
           
            int ca = 1;
            return View();
        }

        public ActionResult ThrowE1()//测试
        {
            int i = 1, o = 0;

            int a = i / o;

            return Content(a.ToString());
        }
        public ActionResult ThrowE2()//测试
        {

            try
            {
                Convert.ToDateTime("3333333333333333333");
                
            }
            catch {
                throw new DllNotFoundException();
            }
            return Content("123");


        }
    }
}