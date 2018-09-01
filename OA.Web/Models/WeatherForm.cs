using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Web.Models
{
    public class WeatherForm
    { //    Text: ["8月18日 雷阵雨转大雨", "今日天气实况：气温：24℃；风向/风力：东北风 2级；湿度：93%；紫外线强度：弱。空气质量：良。", "东北风4-5级", "23℃/26℃"],
      //    City: ["山东", "济南"],
      //    Icon: ["/Image/weather/9.gif", "/Image/weather/4.gif"],
      //    Date: "2018/8/18 10:17:42"
        private string ImgPath {
            get {
                return ConfigurationManager.AppSettings["WeatherImgPath"];
            }
        }
        /// <summary>
        /// Text: [
        /// 0:"8月18日 雷阵雨转大雨", 
        /// 1: "今日天气实况：气温：24℃；风向/风力：东北风 2级；湿度：93%；紫外线强度：弱。空气质量：良。",
        /// 2: "东北风4-5级", 
        /// 3:"23℃/26℃"],
        /// </summary>
        public string[] Text { get; set; }

        /// <summary>
        /// City: [
        /// 0:"山东", 
        /// 1:"济南"],
        /// </summary>
        public string[] City { get; set; }

        /// <summary>
        ///  Icon: [
        /// 0: "/Image/weather/9.gif",
        /// 1: "/Image/weather/4.gif"],
        /// </summary>
        private string[] _Icon;
        public string[] Icon {
            get {
                return _Icon;
            }
            set {
                _Icon = new string[2];
                _Icon[0] = ImgPath + value[0];
                _Icon[1] = ImgPath + value[1];
            }

        }

        public string Date { get; set; }
    }
}
