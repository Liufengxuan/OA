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
<<<<<<< HEAD
            IDAL.IDBSession dBSession = (IDAL.IDBSession)CallContext.GetData("dbSession");
=======
<<<<<<< HEAD
            IDAL.IDBSession dBSession = (IDAL.IDBSession)CallContext.GetData("dbSession");
=======
            IDAL.IDBSession dBSession = (IDAL.IDBSession)CallContext.GetData("dbContext");
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
            if (dBSession == null)
            {
                dBSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", dBSession);
            }
            return dBSession;
        }
       
    }
}
