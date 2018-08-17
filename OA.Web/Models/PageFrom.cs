using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Models
{
    public class PageFrom
    {
        /// <summary>
        /// 数据总数
        /// </summary>
        public int Total { get; set; }


        /// <summary>
        /// 每页条数
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>      
        public string SearchByName { get; set; }
    }
}