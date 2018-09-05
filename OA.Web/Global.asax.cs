using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath(@"\App_Data\Config\Log4NetConfig.xml")));


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ThreadPool.QueueUserWorkItem(h => {
                while (true) {
                    if (Common.RedisHelper.GetListCount("ExceptionQueue")>0)
                    {
                        string  ex = Common.RedisHelper.Dequeue("ExceptionQueue");
                        if (!string.IsNullOrEmpty(ex))
                        {
                            ILog log = LogManager.GetLogger("OAWebLogger");
                            log.Error(ex);
                        }
                        else Thread.Sleep(3000);
                    }
                    else Thread.Sleep(5000);

                }
            }, "");

        }
    }
}
