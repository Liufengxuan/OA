//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Weekly
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string JobContent { get; set; }
        public string JobSum { get; set; }
        public System.DateTime SubTime { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public double avgScore { get; set; }
        public string Upvote { get; set; }
        public string Downvote { get; set; }
        public string Remark { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
