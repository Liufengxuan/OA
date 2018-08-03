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
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //重写父类的SetCurrentDal给父类设置一个数据操作类对象。
        public override void SetCurrentDal()
        {
            CurrentDal = CurrentDBSession.UserInfoDal;
        }
    }
}
