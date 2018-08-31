using OA.DALFactory;
using OA.IBLL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //重写父类的SetCurrentDal给父类设置一个数据操作类对象。
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = CurrentDBSession.UserInfoDal;
        //}




        /// <summary>
        /// 批量删除多条用户数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }

        
        //public IQueryable<UserInfo> LoadSearchEntities(Model.Search.UserInfoSearch userInfoSearch, short delFlag)
        //{
        //    var temp = this.CurrentDBSession.UserInfoDal.LoadEntities(c => c.DelFlag == delFlag);
        //  
        //    if (!string.IsNullOrEmpty(userInfoSearch.UserName))
        //    {
        //        temp = temp.Where<UserInfo>(u => u.UName.Contains(userInfoSearch.UserName));
        //    }
        //    if (!string.IsNullOrEmpty(userInfoSearch.UserRemark))
        //    {
        //        temp = temp.Where<UserInfo>(u => u.Remark.Contains(userInfoSearch.UserRemark));
        //    }
        //    userInfoSearch.TotalCount = temp.Count();
        //    return temp.OrderBy<UserInfo, int>(u => u.ID).Skip<UserInfo>((userInfoSearch.PageIndex - 1) * userInfoSearch.PageSize).Take<UserInfo>(userInfoSearch.PageSize);
        //}



        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleIdList">要分配的角色的编号</param>
        /// <returns></returns>
        public bool SetUserRoleInfo(int userId, List<int> roleIdList)
        {
            var userInfo = this.CurrentDBSession.UserInfoDal.LoadEntities(u => u.ID == userId).FirstOrDefault();//根据用户的编号查找用户的信息
            if (userInfo != null)
            {
                userInfo.RoleInfo.Clear();
                foreach (int roleId in roleIdList)
                {
                    var roleInfo = this.CurrentDBSession.RoleInfoDal.LoadEntities(r => r.ID == roleId).FirstOrDefault();
                    userInfo.RoleInfo.Add(roleInfo);
                }
                return this.CurrentDBSession.SaveChanges();
            }
            return false;

        }

        /// <summary>
        /// 用户权限的分配
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="userId"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public bool SetUserActionInfo(int actionId, int userId, bool isPass)
        {
            var r_userInfo_actionInfo = this.CurrentDBSession.R_UserInfo_ActionInfoDal.LoadEntities(a => a.ActionInfoID == actionId && a.UserInfoID == userId).FirstOrDefault();
            if (r_userInfo_actionInfo == null)
            {
                R_UserInfo_ActionInfo userInfoActionInfo = new R_UserInfo_ActionInfo();
                userInfoActionInfo.ActionInfoID = actionId;
                userInfoActionInfo.UserInfoID = userId;
                userInfoActionInfo.IsPass = isPass;
                this.CurrentDBSession.R_UserInfo_ActionInfoDal.AddEntity(userInfoActionInfo);
            }
            else
            {
                r_userInfo_actionInfo.IsPass = isPass;
                this.CurrentDBSession.R_UserInfo_ActionInfoDal.EditEntity(r_userInfo_actionInfo);
            }
            return this.CurrentDBSession.SaveChanges();

        }


    }
}
