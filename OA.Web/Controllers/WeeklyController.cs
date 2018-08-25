using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class WeeklyController : BaseController
    {

        IBLL.IWeeklyService weeklyService = ServiceFactory.SevSession.GetWeeklyService();
        // GET: Weekly
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetWeeklys()
        {
            var weeklys= weeklyService.LoadEntities(w => 1 == 1);
            return Content(Common.SerializeHelper.SerializeToString(new { weeklys = weeklys, state = 0, msg = "获取到日志" }));
        }

        public ActionResult UpdateScore(Models.RateForm form)
        {
            
            Model.Weekly weekly= weeklyService.LoadEntities(w => w.Id == form.Id).FirstOrDefault();
            if (weekly == null)
            {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 1, msg = "该篇周报已被删除！" }));

            }
            weekly.Score = form.Score;
            weekly.Upvote = form.Upvote;
            weekly.avgScore = form.avgScore;
            if (weeklyService.EditEntity(weekly))
            {
                return Content(Common.SerializeHelper.SerializeToString(new { state = 0, msg = "评分成功！" }));
            }
            return Content(Common.SerializeHelper.SerializeToString(new { state = 1, msg = "评分失败！" }));
        }

      
    }
}