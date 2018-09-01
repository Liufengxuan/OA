using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common
{
   public class MemcacheHelper
    {
       private static readonly MemcachedClient mc = null;

       static MemcacheHelper()
       {
            string[] serverlist = new string[] { ConfigurationManager.AppSettings["MemcacheAddress"] };

           //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
           pool.SetServers(serverlist);

           pool.InitConnections = 3;
           pool.MinConnections = 3;
           pool.MaxConnections = 5;

           pool.SocketConnectTimeout = 1000;
           pool.SocketTimeout = 3000;

           pool.MaintenanceSleep = 30;
           pool.Failover = true;

           pool.Nagle = false;
           pool.Initialize();

           // 获得客户端实例
            mc = new MemcachedClient();
           mc.EnableCompression = false;
       }







        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="time">过期时间</param>
        /// <returns>SessionId</returns>
        public static string Set(object value, DateTime time)
        {
            string key = Guid.NewGuid().ToString();
            bool rst = mc.Set(key, value, time);
            if (rst == false)
            {
                return "";
            }
            return key;
        }


       // /// <summary>
       // /// 存储数据
       // /// </summary>
       // /// <param name="key"></param>
       // /// <param name="value"></param>
       // /// <returns></returns>
       // public static bool Set(string key,object value)
       //{
       //   return mc.Set(key, value);
       //}
        public static bool Set(string key, object value, DateTime time)
        {
            return mc.Set(key, value, time);
        }
 
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
       {
           return mc.Get(key);
       }

      
        public static object GetAndAddMinutes(string key, int Minutes)
        {
            object o = null;
              o=  mc.Get(key);
            if (o != null)
            {
               mc.Set(key, o.ToString(), DateTime.Now.AddMinutes(Minutes));

            }
            return o;
        }



       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
        public static bool Delete(string key)
       {
           if (mc.KeyExists(key))
           {
               return mc.Delete(key);

           }
           return false;

       }
    }
}
