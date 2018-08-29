using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    //数据会话层的接口。
    public partial interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();


        int ExecuteSql(string sql, params SqlParameter[] pars);

        List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars);
        







    }
}
