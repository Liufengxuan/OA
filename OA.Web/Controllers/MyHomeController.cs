using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.Model.EnumType;

namespace OA.Web.Controllers
{
    public class MyHomeController : MessageController
    {
        IBLL.IUserMessageService userMessageService = ServiceFactory.SevSession.GetUserMessageService();
        // GET: MyHome
        [HttpGet]
        public ActionResult Index()
        {
           
           ViewData["weather"] = "{\"Text\":[\"9月3日 多云转晴\",\"今日天气实况：气温：25℃；风向 / 风力：南风 1级；湿度：93 %；紫外线强度：中等。空气质量：中。\",\"北风小于3级\",\"20℃/ 32℃\"],\"City\":[\"山东\",\"济南\"],\"Icon\":[\" /Image/weather/1.gif\",\" /Image/weather/0.gif\"],\"Date\":\"2018 / 9 / 3 8:42:10\"}";//test


            //ViewData["weather"] =Common.SerializeHelper.SerializeToString(base.GetWeather());//获取实时天气
            return View();
        }

        [HttpGet]
        public ActionResult GetUnreadMsgCount()
        {
            return Content(GetUnreadMsgCountGroupByType());
        }


        [HttpPost]
        public ActionResult GetMsgList(int typeId,bool isRead)
        {
           var query = userMessageService.GetMsgListByTypeId(GetActiveUserInfo().ID, typeId, isRead?IsRead.YES:IsRead.NO).ToList();
            if (query != null)
            {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 0, msg = "加载成功", rst = query.ToList<Announcement>() }));
            }
            else {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 1, msg = "没有获取到数据" }));
            }
        }
    }
}