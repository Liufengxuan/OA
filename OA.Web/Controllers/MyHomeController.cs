using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class MyHomeController : BaseController
    {
        // GET: MyHome
        public ActionResult Index()
        {
            ViewData["weather"] =Common.SerializeHelper.SerializeToString(base.GetWeather());
            return View();
        }
    }
}