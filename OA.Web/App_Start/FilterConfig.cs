﻿using OA.Web.Filter;
using System.Web;
using System.Web.Mvc;

namespace OA.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new OAExceptionAttribute());
        }
    }
}
