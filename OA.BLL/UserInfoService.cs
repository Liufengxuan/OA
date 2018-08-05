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
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //重写父类的SetCurrentDal给父类设置一个数据操作类对象。
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = CurrentDBSession.UserInfoDal;
        //}
<<<<<<< HEAD
=======
=======
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //重写父类的SetCurrentDal给父类设置一个数据操作类对象。
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.UserInfoDal;
        }
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
    }
}
