﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public partial interface INotepaperService:IBaseService<Model.Notepaper>
    {
        int AddEntityAndGetNewNotepaperId(Model.Notepaper entity);

    }
}
