using OA.DAL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{

    /// <summary>
    /// 工厂类，负责完成所有数据操作类实例的创建。然后业务层通过数据会话层来获取要数据操作类的实例。
    ///提供 OAEntities（DbContext）的SaveChange统一调用。
    /// </summary>
    public class DBSession:IDBSession
    {

        /// <summary>
        /// 调用  DAL.DBContextFactory.CreateDbContext 方法从CallContext数据曹获取线程内唯一的dbcontext。
        /// </summary>
        public DbContext Db
        {
            get
            {
                return DAL.DBContextFactory.CreateDbContext();
            }
        }



        private IUserInfoDAL _userInfoDal;
        //通过调用抽象工厂创建类的实例。
        public IUserInfoDAL UserInfoDal
        {
            get
            {
                if (_userInfoDal == null)
                {
                    _userInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _userInfoDal;
            }
            set
            {
                _userInfoDal = value;
            }
        }




        /// <summary>
        /// 连接一次数据库，提交对多张表的操作。提高性能。(工作单元模式)
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
