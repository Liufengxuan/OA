using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
     public partial class NotepaperService: BaseService<Model.Notepaper>,IBLL.INotepaperService
    {
        public int AddEntityAndGetNewNotepaperId(Model.Notepaper entity)
        {
            CurrentDBSession.NotepaperDal.AddEntity(entity);
            if (CurrentDBSession.SaveChanges())
            {
                return entity.Id;
            }
            else {

                return 0;
            }
        }
    }
}
