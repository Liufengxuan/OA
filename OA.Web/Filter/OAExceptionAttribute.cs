using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OA.Web.Filter
{
    public class OAExceptionAttribute:HandleErrorAttribute
    {
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

       
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            if (ex == null)
            {
                return;
            }
            Common.RedisHelper.Enqueue("ExceptionQueue", ex.ToString());
            filterContext.ExceptionHandled = true;


            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new { state = 1, msg = "由于服务器异常加载失败、请联系管理员" }
                };
                return;
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/static/Error/error.html");
                filterContext.Result = new EmptyResult();
            }
           
        }
    }
}