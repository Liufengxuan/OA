using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model
{
    public class CompleteUserInfo
    {
        public int Id { get; set; }
        public string UName { get; set; }
        public string SubTime { get; set; }
        public short DelFlag { get; set; }
        public string Remark { get; set; }
        public string Sort { get; set; }

        public int RId { get; set; }
        public string RName { get; set; }
        public string RRemark { get; set; }
        public string RSort { get; set; }
        
        public int DId { get; set; }
        public string DepName { get; set; }
       
    }
}
