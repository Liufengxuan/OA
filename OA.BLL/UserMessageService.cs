using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public partial class UserMessageService : BaseService<UserMessage>, IUserMessageService
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="typeId">0是全部获取</param>
        /// <param name="isRead">0是未读、1是已读</param>
        /// <returns></returns>
        public IQueryable<Announcement> GetMsgListByTypeId(int UserId, int typeId,Model.EnumType.IsRead isRead)
        {
            System.Linq.Expressions.Expression<Func<UserMessage, bool>> lmd;
            if (typeId == 0)
            {
                lmd = (u) => u.UserId == UserId && u.IsRead == (short)isRead;
            }
            else {
                lmd = (u) => u.UserId == UserId && u.Announcement.AnnounTypeId == typeId && u.IsRead == (short)isRead;

            }
             return LoadEntities(lmd).Select(a=>a.Announcement);
        }
        
    }
}
