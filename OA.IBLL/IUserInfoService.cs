using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        bool DeleteEntities(List<int> list);
        bool SetUserRoleInfo(int userId, List<int> roleIdList);
        bool SetUserActionInfo(int actionId, int userId, bool isPass);
    }
}
