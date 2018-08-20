using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Models
{
    public class AddUserForm
    {
        public int ID { get; set; }
        public string UName { get; set; }
        public int DelFlag { get; set; }
        public int DepId { get; set; }
        public int RoleId { get; set; }
    }
}