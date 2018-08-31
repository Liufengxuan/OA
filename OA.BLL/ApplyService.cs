using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace OA.BLL
{
   public partial class ApplyService:BaseService<Apply>,IApplyService
    {
        public bool HandleApply(int aId, int aState, string remark2)
        {
            string sql = "update Apply set apply.State=@state,apply.Remark2=@remark where apply.Id=@id";
            SqlParameter[] pars = {
                new SqlParameter("@state",System.Data.SqlDbType.Int),
                new SqlParameter("@remark",System.Data.SqlDbType.NVarChar,50),
                new SqlParameter("@id",System.Data.SqlDbType.Int,50)
            };
            pars[0].Value = aState;
            pars[1].Value = remark2;
            pars[2].Value = aId;

            return CurrentDBSession.ExecuteSql(sql, pars) > 0;
        }
    }
}
