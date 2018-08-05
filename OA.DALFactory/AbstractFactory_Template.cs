﻿ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using OA.IDAL;

namespace OA.DALFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IActionInfoDAL CreateActionInfoDal()
        {

		 string fullClassName = NameSpace + ".ActionInfoDAL";
          return CreateInstance(fullClassName) as IActionInfoDAL;

        }
		
	    public static IBooksDAL CreateBooksDal()
        {

		 string fullClassName = NameSpace + ".BooksDAL";
          return CreateInstance(fullClassName) as IBooksDAL;

        }
		
	    public static IDepartmentDAL CreateDepartmentDal()
        {

		 string fullClassName = NameSpace + ".DepartmentDAL";
          return CreateInstance(fullClassName) as IDepartmentDAL;

        }
		
	    public static IKeyWordsRankDAL CreateKeyWordsRankDal()
        {

		 string fullClassName = NameSpace + ".KeyWordsRankDAL";
          return CreateInstance(fullClassName) as IKeyWordsRankDAL;

        }
		
	    public static IR_UserInfo_ActionInfoDAL CreateR_UserInfo_ActionInfoDal()
        {

		 string fullClassName = NameSpace + ".R_UserInfo_ActionInfoDAL";
          return CreateInstance(fullClassName) as IR_UserInfo_ActionInfoDAL;

        }
		
	    public static IRoleInfoDAL CreateRoleInfoDal()
        {

		 string fullClassName = NameSpace + ".RoleInfoDAL";
          return CreateInstance(fullClassName) as IRoleInfoDAL;

        }
		
	    public static ISearchDetailsDAL CreateSearchDetailsDal()
        {

		 string fullClassName = NameSpace + ".SearchDetailsDAL";
          return CreateInstance(fullClassName) as ISearchDetailsDAL;

        }
		
	    public static IUserInfoDAL CreateUserInfoDal()
        {

		 string fullClassName = NameSpace + ".UserInfoDAL";
          return CreateInstance(fullClassName) as IUserInfoDAL;

        }
	}
	
}