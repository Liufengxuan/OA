 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.BLL;
using OA.IBLL;


namespace ServiceFactory
{
public partial class SevSession
    {
	
	public static IActionInfoService  GetActionInfoService()
    {
		  return new ActionInfoService();
    }   
	
	public static IAnnouncementService  GetAnnouncementService()
    {
		  return new AnnouncementService();
    }   
	
	public static IAnnounTypeService  GetAnnounTypeService()
    {
		  return new AnnounTypeService();
    }   
	
	public static IApplyService  GetApplyService()
    {
		  return new ApplyService();
    }   
	
	public static IApplyTypeService  GetApplyTypeService()
    {
		  return new ApplyTypeService();
    }   
	
	public static IBooksService  GetBooksService()
    {
		  return new BooksService();
    }   
	
	public static IDepartmentService  GetDepartmentService()
    {
		  return new DepartmentService();
    }   
	
	public static IKeyWordsRankService  GetKeyWordsRankService()
    {
		  return new KeyWordsRankService();
    }   
	
	public static INotepaperService  GetNotepaperService()
    {
		  return new NotepaperService();
    }   
	
	public static IR_UserInfo_ActionInfoService  GetR_UserInfo_ActionInfoService()
    {
		  return new R_UserInfo_ActionInfoService();
    }   
	
	public static IRoleInfoService  GetRoleInfoService()
    {
		  return new RoleInfoService();
    }   
	
	public static ISearchDetailsService  GetSearchDetailsService()
    {
		  return new SearchDetailsService();
    }   
	
	public static IUserInfoService  GetUserInfoService()
    {
		  return new UserInfoService();
    }   
	
	public static IUserMessageService  GetUserMessageService()
    {
		  return new UserMessageService();
    }   
	
	public static IWeeklyService  GetWeeklyService()
    {
		  return new WeeklyService();
    }   
	}
}