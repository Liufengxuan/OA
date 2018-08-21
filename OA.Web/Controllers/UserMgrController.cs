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
        IBLL.IDepartmentService departmentService = ServiceFactory.SevSession.GetDepartmentService();
        // GET: UserMgr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserInfo(Models.PageForm pageFrom)
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
                var u2 = userInfoService.LoadPageEntities<int>(pageFrom.Current, pageFrom.Size, out totalCount, u => u.DelFlag <2, u =>u.ID, true);
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
                c.DelFlag = item.DelFlag;

                rst.Add(c);
            }
            #endregion 


            return Content(SerializeHelper.SerializeToString(new { list = rst, total = pageFrom.Total, size = pageFrom.Size, current = pageFrom.Current }));
        }

        public ActionResult GetDepInfo()
        {
            var depList= departmentService.LoadEntities(d => 1 == 1);
            return Content(SerializeHelper.SerializeToString(depList));
        }

        public ActionResult GetRoleInfo(string depId)
        {
            if (depId == null)
            {
                return Content("");
            }
            string pms = depId.ToString() + ".";
            var roleList = roleInfoService.LoadEntities(r => r.Sort.StartsWith(pms));
            return Content(SerializeHelper.SerializeToString(roleList));
        }


        public ActionResult AddUser(Models.AddUserForm form)
        {
            UserInfo userInfo = new UserInfo();
            if (form.ID == 0)
            {
                userInfo.UName = form.UName;
                userInfo.RoleInfo.Add(roleInfoService.LoadEntities(r => r.ID == form.RoleId).FirstOrDefault<RoleInfo>());
                userInfo.Department.Add(departmentService.LoadEntities(d => d.ID == form.DepId).FirstOrDefault<Department>());
                userInfo.UPwd = new Random().Next(100000, 999999).ToString();
                userInfo.SubTime = DateTime.Now;
                userInfo.ModifiedOn = userInfo.SubTime;
                userInfo.Sort = userInfo.RoleInfo.FirstOrDefault().Sort;
                userInfo.DelFlag = (short)form.DelFlag;
                if (userInfoService.AddEntity(userInfo))
                {
                    userInfo = userInfoService.LoadEntities(u => form.UName == u.UName && u.UPwd == userInfo.UPwd).FirstOrDefault();
                    if (userInfo.DelFlag == 1)
                    {
                        return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "添加成功,但该账号处于禁用状态", userinfo = userInfo }));
                    }
                    return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "添加成功", userinfo = userInfo }));
                }
            }
            
            return Content(SerializeHelper.SerializeToString(new { state=1,msg="添加失败"}));          
        }


        public ActionResult EditUser(Models.AddUserForm form)
        {
            UserInfo editUserInfo = new UserInfo();
            int editCount = 0;
            if (form.ID > 0)
            {
                editUserInfo = userInfoService.LoadEntities(u => u.ID == form.ID).FirstOrDefault();

                if (form.UName != editUserInfo.UName)
                {
                    editUserInfo.UName = form.UName;
                    editCount++;
                }
                if (form.RoleId != editUserInfo.RoleInfo.FirstOrDefault().ID)
                {
                    editUserInfo.RoleInfo.Clear();
                    editUserInfo.RoleInfo.Add( roleInfoService.LoadEntities(r => r.ID == form.RoleId).FirstOrDefault());
                    editCount++;
                }
                if (form.DepId != editUserInfo.Department.FirstOrDefault().ID)
                {
                    editUserInfo.Department.Clear();
                    editUserInfo.Department.Add(departmentService.LoadEntities(d => d.ID == form.DepId).FirstOrDefault());
                    editCount++;
                }
                if ((short)form.DelFlag != editUserInfo.DelFlag)
                {
                    editUserInfo.DelFlag =(short) form.DelFlag;
                    editCount++;
                }
                if (editCount != 0)
                {
                    if (userInfoService.EditEntity(editUserInfo))
                    {
                        return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "修改成功！" }));
                    }
                    else {
                        return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "修改失败！" }));

                    }
                        
                }             
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "无修改项" }));

        }

    }
}