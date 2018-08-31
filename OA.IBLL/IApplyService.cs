using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public partial interface IApplyService:IBaseService<Apply>
    {
        bool HandleApply(int aId, int aState, string remark2);
    }
}
