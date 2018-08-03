0802：在dal  增加获取EF数据操作上下文方法  。在CallContext中单例存取
	  DBSession调用  DAL.DBContextFactory.CreateDbContext 方法从CallContext数据曹获取线程内唯一的dbcontext。
	  后期所有数据操作类要在：OA.DALFactory.AbstractFactory中配置反射。
							  OA.DALFactory.DBSession中增加相应数据操作类字段。
				


0803：解决BLL中的BaseService<T> 不能写死里面负责增删该查的某一个DAL类：
		1.-->将这个类设置为抽象类
	public abstract class BaseService<T> where T:class,new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                return new DBSession();//后期这里要改用工厂类创建。
            }
        }

        2.-->用来存储一个具体的数据操作类。
        public IBaseDAL<T> CurrentDal { get; set; }


        3.-->子类必须重写这个方法来给此类中的 CurrentDal字段赋值一个具体的数据操作类！
        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }
		
		