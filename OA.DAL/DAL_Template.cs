 

using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL
{
		
	public partial class ActionInfoDAL :BaseDAL<ActionInfo>,IActionInfoDAL
    {

    }
		
	public partial class BooksDAL :BaseDAL<Books>,IBooksDAL
    {

    }
		
	public partial class DepartmentDAL :BaseDAL<Department>,IDepartmentDAL
    {

    }
		
	public partial class KeyWordsRankDAL :BaseDAL<KeyWordsRank>,IKeyWordsRankDAL
    {

    }
		
	public partial class R_UserInfo_ActionInfoDAL :BaseDAL<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDAL
    {

    }
		
	public partial class RoleInfoDAL :BaseDAL<RoleInfo>,IRoleInfoDAL
    {

    }
		
	public partial class SearchDetailsDAL :BaseDAL<SearchDetails>,ISearchDetailsDAL
    {

    }
		
	public partial class UserInfoDAL :BaseDAL<UserInfo>,IUserInfoDAL
    {

    }
		
	public partial class WeeklyDAL :BaseDAL<Weekly>,IWeeklyDAL
    {

    }
	
}