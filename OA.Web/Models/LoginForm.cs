using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Models
{
    public class LoginForm
    {
        public string user { get; set; }

        public string pwd { get; set; }
        public string code { get; set; }

        public string checkpwd { get; set; }


    }
}