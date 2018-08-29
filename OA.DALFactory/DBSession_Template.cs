 
using OA.DAL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace  OA.DALFactory
{
	internal partial class DBSession : IDBSession
    {
	
		private IActionInfoDAL _ActionInfoDal;
        public IActionInfoDAL ActionInfoDal
        {
            get
            {
                if(_ActionInfoDal == null)
                {
                    _ActionInfoDal = AbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }
	
		private IApplyDAL _ApplyDal;
        public IApplyDAL ApplyDal
        {
            get
            {
                if(_ApplyDal == null)
                {
                    _ApplyDal = AbstractFactory.CreateApplyDal();
                }
                return _ApplyDal;
            }
            set { _ApplyDal = value; }
        }
	
		private IApplyTypeDAL _ApplyTypeDal;
        public IApplyTypeDAL ApplyTypeDal
        {
            get
            {
                if(_ApplyTypeDal == null)
                {
                    _ApplyTypeDal = AbstractFactory.CreateApplyTypeDal();
                }
                return _ApplyTypeDal;
            }
            set { _ApplyTypeDal = value; }
        }
	
		private IBooksDAL _BooksDal;
        public IBooksDAL BooksDal
        {
            get
            {
                if(_BooksDal == null)
                {
                    _BooksDal = AbstractFactory.CreateBooksDal();
                }
                return _BooksDal;
            }
            set { _BooksDal = value; }
        }
	
		private IDepartmentDAL _DepartmentDal;
        public IDepartmentDAL DepartmentDal
        {
            get
            {
                if(_DepartmentDal == null)
                {
                    _DepartmentDal = AbstractFactory.CreateDepartmentDal();
                }
                return _DepartmentDal;
            }
            set { _DepartmentDal = value; }
        }
	
		private IKeyWordsRankDAL _KeyWordsRankDal;
        public IKeyWordsRankDAL KeyWordsRankDal
        {
            get
            {
                if(_KeyWordsRankDal == null)
                {
                    _KeyWordsRankDal = AbstractFactory.CreateKeyWordsRankDal();
                }
                return _KeyWordsRankDal;
            }
            set { _KeyWordsRankDal = value; }
        }
	
		private IR_UserInfo_ActionInfoDAL _R_UserInfo_ActionInfoDal;
        public IR_UserInfo_ActionInfoDAL R_UserInfo_ActionInfoDal
        {
            get
            {
                if(_R_UserInfo_ActionInfoDal == null)
                {
                    _R_UserInfo_ActionInfoDal = AbstractFactory.CreateR_UserInfo_ActionInfoDal();
                }
                return _R_UserInfo_ActionInfoDal;
            }
            set { _R_UserInfo_ActionInfoDal = value; }
        }
	
		private IRoleInfoDAL _RoleInfoDal;
        public IRoleInfoDAL RoleInfoDal
        {
            get
            {
                if(_RoleInfoDal == null)
                {
                    _RoleInfoDal = AbstractFactory.CreateRoleInfoDal();
                }
                return _RoleInfoDal;
            }
            set { _RoleInfoDal = value; }
        }
	
		private ISearchDetailsDAL _SearchDetailsDal;
        public ISearchDetailsDAL SearchDetailsDal
        {
            get
            {
                if(_SearchDetailsDal == null)
                {
                    _SearchDetailsDal = AbstractFactory.CreateSearchDetailsDal();
                }
                return _SearchDetailsDal;
            }
            set { _SearchDetailsDal = value; }
        }
	
		private IUserInfoDAL _UserInfoDal;
        public IUserInfoDAL UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                    _UserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
	
		private IWeeklyDAL _WeeklyDal;
        public IWeeklyDAL WeeklyDal
        {
            get
            {
                if(_WeeklyDal == null)
                {
                    _WeeklyDal = AbstractFactory.CreateWeeklyDal();
                }
                return _WeeklyDal;
            }
            set { _WeeklyDal = value; }
        }
	}	
}