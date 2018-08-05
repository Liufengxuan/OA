using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDAL.IDBSession CreateDBSession()
        {
            IDAL.IDBSession dBSession = (IDAL.IDBSession)CallContext.GetData("dbSession");
            if (dBSession == null)
            {
                dBSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", dBSession);
            }
            return dBSession;
        }
       
    }
}
