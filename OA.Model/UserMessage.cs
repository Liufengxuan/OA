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
    
    public partial class UserMessage
    {
        public int Id { get; set; }
        public int AnnounId { get; set; }
        public int UserId { get; set; }
        public short IsRead { get; set; }
        public Nullable<System.DateTime> ReadTime { get; set; }
        public string Remark { get; set; }
    
        public virtual Announcement Announcement { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
