﻿using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
   public partial interface IUserMessageService: IBaseService<UserMessage>
    {
        IQueryable<Announcement> GetMsgListByTypeId(int UserId, int typeId, Model.EnumType.IsRead isRead);

    }
}