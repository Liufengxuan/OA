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

        public ActionResult GetUserInfo(Models.PageFrom pageFrom)
        {
            //string userInfoSID = Request.Cookies["userInfoSID"].Value;
            //Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.Get(userInfoSID).ToString());
            //var rst = userInfoService.LoadEntities(U => Convert.ToInt32(U.Sort) < Convert.ToInt32(userInfo.Sort));
            List<Model.UserInfo> userInfoList = null;
            int totalCount = 0;
            if (pageFrom.SearchByName != ""&&pageFrom.SearchByName!=null)
            {
                pageFrom.Current = 1;
               var u1 = userInfoService.LoadPageEntities<int>(pageFrom.Current, pageFrom.Size, out totalCount, u => u.UName.Contains(pageFrom.SearchByName)&&u.DelFlag!=1, u => u.ID, true);
                userInfoList = u1.ToList<UserInfo>();
            }
            else
            {
                var u2 = userInfoService.LoadPageEntities<int>(pageFrom.Current, pageFrom.Size, out totalCount, u => u.DelFlag != 1, u =>u.ID, true);
                userInfoList = u2.ToList<UserInfo>();

            }
            pageFrom.Total = totalCount;

        
            //整理数据
            #region  

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
            #endregion 


            return Content(SerializeHelper.SerializeToString(new { list = rst, total = pageFrom.Total, size = pageFrom.Size, current = pageFrom.Current }));
        }
    }
}