using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Common;
using OA.Model;
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


        public ActionResult GetWeeklys(string start, string end)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            var weeklys= weeklyService.LoadEntities(w => w.SubTime>=startDate&&w.SubTime<=endDate);

            //注释启用按周查询
            weeklys = weeklyService.LoadEntities(w => 1 == 1); 

            if (weeklys == null)
            {
                return Content(Common.SerializeHelper.SerializeToString(new { weeklys = weeklys, state =1, msg = "没有查询到"+start+"至"+end+"这一周的周报" }));
            }
            else if (weeklys != null)
            {
                return Content(Common.SerializeHelper.SerializeToString(new { weeklys = weeklys, state = 0, msg = "获取到日志" }));
            }
            return Content(Common.SerializeHelper.SerializeToString(new { weeklys = weeklys, state = 1, msg = "服务器查询出错" }));

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

        public ActionResult WriteWeekly()
        {
            DateTime weekStartDate = WeekHelper.GetMondayDate();
            DateTime weekEndDate = WeekHelper.GetSundayDate();

            string userInfoSID = Request.Cookies["userInfoSID"].Value;
            Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.Get(userInfoSID).ToString());

            Model.Weekly weekly= weeklyService.LoadEntities(w => w.SubTime >= weekStartDate
            && w.SubTime <= weekEndDate
            && w.UserId == userInfo.ID).FirstOrDefault() ;


            if (weekly == null) return View();
            //return View();
            return RedirectToAction("Index", "Weekly");
        }

        public ActionResult SubmitWeekly(Weekly weekly)
        {
            weekly.Score = 0;
            weekly.SubTime = DateTime.Now;
            weekly.avgScore = 0;
            weekly.Upvote = "0";
            if (weeklyService.AddEntity(weekly))
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "提交成功" }));
            }
            else {

                return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "提交失败" }));
            }
            

        }
    }
}