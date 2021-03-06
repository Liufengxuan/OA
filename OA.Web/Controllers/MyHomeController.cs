﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.Model.EnumType;
using OA.Common;

namespace OA.Web.Controllers
{
    public class MyHomeController : MessageController
    {
        IBLL.IUserMessageService userMessageService = ServiceFactory.SevSession.GetUserMessageService();
        IBLL.INotepaperService notepaperService = ServiceFactory.SevSession.GetNotepaperService();
        // GET: MyHome
        [HttpGet]
        public ActionResult Index()
        {

            //ViewData["weather"] = "{\"Text\":[\"9月3日 多云转晴\",\"今日天气实况：气温：25℃；风向 / 风力：南风 1级；湿度：93 %；紫外线强度：中等。空气质量：中。\",\"北风小于3级\",\"20℃/ 32℃\"],\"City\":[\"山东\",\"济南\"],\"Icon\":[\" /Image/weather/1.gif\",\" /Image/weather/0.gif\"],\"Date\":\"2018 / 9 / 3 8:42:10\"}";//test
            string cache= RedisHelper.Get<string>("weather");     //他妈的这个redis 存对象有问题、坑。还是序列化后再存吧
            if(cache == null) {
                cache = Common.SerializeHelper.SerializeToString(GetWeather());
                RedisHelper.Set("weather", cache, DateTime.Now.AddHours(4));     
            }
            ViewData["weather"] = cache;//获取实时天气
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


        [HttpPost]
        public ActionResult ChangeReadState(int MsgId)
        {
            int id = GetActiveUserInfo().ID;
            UserMessage uM=userMessageService.LoadEntities(u => u.UserId == id&&u.AnnounId==MsgId).FirstOrDefault();
            uM.IsRead = 1;
            uM.ReadTime = DateTime.Now;
            if (userMessageService.EditEntity(uM))
            {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 0, msg = "已读取该内容。" }));
                
            }
            return Content(Common.SerializeHelper.SerializeToString(new { state = 1, msg = "操作失败" }));
           
        }

        [HttpPost]
        public ActionResult GetNotePaperList(int condition)
        {
            //condition
            //0今天、1待做、2历史
            DateTime startDate = DateTime.Today;
            DateTime EndDate = DateTime.Today.AddDays(86399F / 86400);

            //测试
            startDate = Convert.ToDateTime("2018-09-04 00:00:00.000");
            EndDate = Convert.ToDateTime("2018-09-04 23:59:00.000");






            int id=GetActiveUserInfo().ID;
            double total,completeCount,progress;
            System.Linq.Expressions.Expression<Func<Model.Notepaper, bool>> lmd = n => n.UserId == id && n.SubTime > startDate && n.SubTime < EndDate;
            var query= notepaperService.LoadEntities(lmd);
            List<Notepaper> list = query.ToList();
            total = list.Count();
            completeCount =list.Where(u => u.IsComplete == 0).Count();
            progress = total == 0 ? 0 : (completeCount / total) * 100;

            if (condition == 0)
            {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 0, msg = "获取成功", rst = query, progress = progress }));
            }


            if (condition == 1)
            {
                lmd = n => n.UserId == id && n.IsComplete == 0;
            }
            else if (condition == 2)
            {
                lmd = n => n.UserId == id && /*n.SubTime < startDate &&*/ n.IsComplete == 1;
            }
             query = notepaperService.LoadEntities(lmd);

            return Content(Common.SerializeHelper.SerializeToString(new { state = 0, msg = "获取成功", rst = query, progress = progress }));
        }

        [HttpGet]
        public ActionResult ChangeNotepaperState(int npId)
        {
            Model.UserInfo u= GetActiveUserInfo();

            Model.Notepaper notepaper = notepaperService.LoadEntities(n => n.Id == npId&&u.ID==n.UserId).FirstOrDefault();

            notepaper.IsComplete = 1;
            if (notepaperService.EditEntity(notepaper))
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已完成 “" + notepaper.Context + "”" }));
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "服务器出错" }));
        }

        [HttpGet]
        public ActionResult DeleteNotepaperById(int npId)
        {
            Model.UserInfo userInfo = GetActiveUserInfo();

           Notepaper np= notepaperService.LoadEntities(n => n.Id == npId && n.UserId == userInfo.ID).FirstOrDefault();
            if (notepaperService.DeleteEntity(np))
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已删除该条消息" }));
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "删除失败" }));
        }


        [HttpPost]
        public ActionResult AddNotepaper(string text)
        {
            Model.UserInfo u= GetActiveUserInfo();

            Model.Notepaper notepaper = new Notepaper() {
                Context = text,
                IsComplete = 0,
                UserId = u.ID,
                SubTime = DateTime.Now,
            };
            int newId = notepaperService.AddEntityAndGetNewNotepaperId(notepaper);
            if (0< newId)
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已添加",NewNotepaper=notepaperService.LoadEntities(n=>n.Id==newId).FirstOrDefault() }));
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "添加失败" }));

        }
    }
}