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
    }
}