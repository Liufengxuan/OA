using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common
{
   public class SerializeHelper
    {
       /// <summary>
       /// 对数据进行序列化
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
       public static string  SerializeToString(object value)
       {
          return JsonConvert.SerializeObject(value);
       }
       /// <summary>
       /// 反序列化操作
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="str"></param>
       /// <returns></returns>
       public static T DeserializeToObject<T>(string str)
       {
          return JsonConvert.DeserializeObject<T>(str);
       }
        public static string JsonRegex(string jsonInput)
        {
            string result = string.Empty;
            try
            {
                string pattern = "\"(\\w+)\"(\\s*:\\s*)";
                string replacement = "$1$2";
                System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
                result = rgx.Replace(jsonInput, replacement);
            }
            catch (Exception ex)
            {
                result = jsonInput;
            }
            return result;
        }



        //public static string JsonToJsObj(string json)
        //{
        //    string[] a = json.Split(',');
        //    string[] temp = new string[] { };
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        temp = a[i].Split(':');
        //        temp[0].Replace("", "");
        //        a[i] = string.Join(":", temp);
        //    }
        //    return string.Join(",", a);
        //}
    }
}
