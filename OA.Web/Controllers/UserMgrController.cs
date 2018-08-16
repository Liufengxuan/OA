using OA.Common;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class UserMgrController : Controller
    {
        IBLL.IUserInfoService userInfoService = ServiceFactory.SevSession.GetUserInfoService();
        IBLL.IRoleInfoService roleInfoService = ServiceFactory.SevSession.GetRoleInfoService();
        // GET: UserMgr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserInfo()
        {
            //string userInfoSID = Request.Cookies["userInfoSID"].Value;
            //Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.Get(userInfoSID).ToString());
            //var rst = userInfoService.LoadEntities(U => Convert.ToInt32(U.Sort) < Convert.ToInt32(userInfo.Sort));
            var userInfos = userInfoService.LoadEntities(u=>1==1);
            List<Model.UserInfo> userInfoList = userInfos.ToList<UserInfo>();


            Department d = null;
            RoleInfo r = null;
            List<CompleteUserInfo> rst = new List<CompleteUserInfo>();
            foreach (UserInfo item in userInfoList)
            {
                CompleteUserInfo c= new CompleteUserInfo();
                if (item.Department.FirstOrDefault() != null)
                {
                    d = item.Department.FirstOrDefault();
                    c.DId = d.ID;
                    c.DepName = d.DepName;

                }
                if (item.RoleInfo.FirstOrDefault() != null)
                {
                    r = item.RoleInfo.FirstOrDefault();
                    c.RId = r.ID;
                    c.RName = r.RoleName;
                    c.Remark = r.Remark;
                    c.RSort = r.Sort;
                }
                c.Id = item.ID;
                c.UName = item.UName;
                c.SubTime = item.SubTime.ToShortDateString();
                c.Remark = item.Remark;
                c.Sort = item.Sort;

                rst.Add(c);
            }


            return Content(SerializeHelper.SerializeToString(new {list= rst }));
        }
    }
}