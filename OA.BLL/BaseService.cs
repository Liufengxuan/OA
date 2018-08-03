using OA.DALFactory;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
     public abstract class BaseService<T> where T:class,new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }

        //用来存储一个具体的数据操作类。
        public IBaseDAL<T> CurrentDal { get; set; }

        /// <summary>
        ///子类应该重写这个方法来给此类中的 CurrentDal字段赋值一个具体的数据操作类！
        /// </summary>
        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }



        /*------------------------------------公共增、删、改、查、分页方法-----------------------------------------------*/

        public bool AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        public bool DeleteEntity(T entity)
        {
           CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public IQueryable<T> LoadPageEntities<s>(int PageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderByLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(PageIndex, pageSize, out totalCount, whereLambda, orderByLambda, isAsc);
        }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

    }
}
