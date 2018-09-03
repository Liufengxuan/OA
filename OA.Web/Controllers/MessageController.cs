using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
      
    public class MessageController : BaseController
    {
        IBLL.IUserMessageService userMessageService = ServiceFactory.SevSession.GetUserMessageService();
        // GET: Message
        protected string GetUnreadMsgCountGroupByType()
        {
            Model.UserInfo userInfo = GetActiveUserInfo();

            var userMessages = userMessageService.LoadEntities(u => u.UserId == userInfo.ID && u.IsRead == 0);
            var rst = from u in userMessages
                      group new { u.Announcement.AnnounType, u.Announcement } by new
                      {
                          u.Announcement.AnnounType.Name,
                          u.Announcement.AnnounType.Id,
                          u.Announcement.AnnounTypeId
                      } into g
                      select new
                      {
                          g.Key.Name,
                          g.Key.Id,
                          Count = g.Count(p => p.Announcement.AnnounTypeId != null)
                      };
            int Sum= rst.Sum(a => a.Count);
            if (rst != null)
            {
                return Common.SerializeHelper.SerializeToString(new {state=0,msg="消息获取成功",rst=rst,Sum=Sum});
            }
            else {
                return Common.SerializeHelper.SerializeToString(new { state = 1, msg = "消息获取失败" });
            }

           

        }
    }
}