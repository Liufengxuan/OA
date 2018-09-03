 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
	public partial interface IDBSession
    {

	
		IActionInfoDAL ActionInfoDal{get;set;}
	
		IAnnouncementDAL AnnouncementDal{get;set;}
	
		IAnnounTypeDAL AnnounTypeDal{get;set;}
	
		IApplyDAL ApplyDal{get;set;}
	
		IApplyTypeDAL ApplyTypeDal{get;set;}
	
		IBooksDAL BooksDal{get;set;}
	
		IDepartmentDAL DepartmentDal{get;set;}
	
		IKeyWordsRankDAL KeyWordsRankDal{get;set;}
	
		INotepaperDAL NotepaperDal{get;set;}
	
		IR_UserInfo_ActionInfoDAL R_UserInfo_ActionInfoDal{get;set;}
	
		IRoleInfoDAL RoleInfoDal{get;set;}
	
		ISearchDetailsDAL SearchDetailsDal{get;set;}
	
		IUserInfoDAL UserInfoDal{get;set;}
	
		IUserMessageDAL UserMessageDal{get;set;}
	
		IWeeklyDAL WeeklyDal{get;set;}
	}	
}