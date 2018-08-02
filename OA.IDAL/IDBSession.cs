using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    //数据会话层的接口。
    public interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();








         IUserInfoDAL UserInfoDal { get; set; }
        

    }
}
