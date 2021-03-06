﻿ 
using OA.DALFactory;
using OA.IBLL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
	
	public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.ActionInfoDal;
        }
    }   
	
	public partial class AnnouncementService :BaseService<Announcement>,IAnnouncementService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.AnnouncementDal;
        }
    }   
	
	public partial class AnnounTypeService :BaseService<AnnounType>,IAnnounTypeService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.AnnounTypeDal;
        }
    }   
	
	public partial class ApplyService :BaseService<Apply>,IApplyService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.ApplyDal;
        }
    }   
	
	public partial class ApplyTypeService :BaseService<ApplyType>,IApplyTypeService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.ApplyTypeDal;
        }
    }   
	
	public partial class BooksService :BaseService<Books>,IBooksService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.BooksDal;
        }
    }   
	
	public partial class DepartmentService :BaseService<Department>,IDepartmentService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.DepartmentDal;
        }
    }   
	
	public partial class KeyWordsRankService :BaseService<KeyWordsRank>,IKeyWordsRankService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.KeyWordsRankDal;
        }
    }   
	
	public partial class NotepaperService :BaseService<Notepaper>,INotepaperService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.NotepaperDal;
        }
    }   
	
	public partial class R_UserInfo_ActionInfoService :BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.R_UserInfo_ActionInfoDal;
        }
    }   
	
	public partial class RoleInfoService :BaseService<RoleInfo>,IRoleInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.RoleInfoDal;
        }
    }   
	
	public partial class SearchDetailsService :BaseService<SearchDetails>,ISearchDetailsService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.SearchDetailsDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }
    }   
	
	public partial class UserMessageService :BaseService<UserMessage>,IUserMessageService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserMessageDal;
        }
    }   
	
	public partial class WeeklyService :BaseService<Weekly>,IWeeklyService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.WeeklyDal;
        }
    }   
	
}