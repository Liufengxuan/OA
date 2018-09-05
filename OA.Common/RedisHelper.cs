using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace OA.Common
{
    public class RedisHelper
    {
       
         
        private static IRedisClient RedisCli = null;

        static RedisHelper()
        {
            string[] addressArr = new string[] { ConfigurationManager.AppSettings["RedisAddress"] };
            IRedisClientsManager redisCliManager = new PooledRedisClientManager();
            RedisCli = redisCliManager.GetClient();
        }

        public static bool Set<T>(string key, T value)
        {
            return RedisCli.Set<T>(key, value);
        }

        /// <summary>
        /// dt 指示多久后过期 如 ：DateTime.Now.AddMinutes(10) 10分钟后过期 （如果设置的时间小于或等于现在的时间那么过期时间设置为10分钟）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool Set<T>(string key, T value, DateTime dt)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan;
            if (dt <= now)
            {
                timeSpan = now.AddMinutes(10) - now;
            }
            else {
                timeSpan = dt - now;

            }
            return RedisCli.Set<T>(key, value,timeSpan);
        }

        public static T Get<T>(string key)
        {
            return RedisCli.Get<T>(key);
        }
        public static void Enqueue(string ListId,string value)
        {
            RedisCli.EnqueueItemOnList(ListId, value);
        }
        public static string Dequeue(string listId)
        {
           return  RedisCli.DequeueItemFromList(listId);
        }
        public static long GetListCount(string ListId)
        {
           return  RedisCli.GetListCount(ListId);
        }

    }
}
