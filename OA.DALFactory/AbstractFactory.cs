using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using OA.IDAL;

namespace OA.DALFactory
{
    /// <summary>
    /// 通过反射的形式创建类的实例。
    /// </summary>
      public partial class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
        //public static IUserInfoDAL CreateUserInfoDal()
        //{
        //    string fullClassName = NameSpace + ".UserInfoDAL";
        //    return CreateInstance(fullClassName) as IUserInfoDAL;
        //}
<<<<<<< HEAD
=======
=======
        public static IUserInfoDAL CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDAL";
            return CreateInstance(fullClassName) as IUserInfoDAL;
        }
>>>>>>> 8d3cf80f65d2dc88b1ae460a00f3210b12c90b89
>>>>>>> d6dbcb7fee3131fe06fc014bb208dea987800b64
        public static object CreateInstance(string className)
        {
            var assembly= Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(className);
        }
    }
}
