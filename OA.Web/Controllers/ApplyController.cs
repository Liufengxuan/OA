using OA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class ApplyController : Controller
    {
        IBLL.IApplyService applyService = ServiceFactory.SevSession.GetApplyService();
        // GET: Apply
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTabTips()
        {
            //string userInfoSID = Request.Cookies["userInfoSID"].Value;
            //Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.Get(userInfoSID).ToString());

            Model.UserInfo userInfo = new Model.UserInfo() { ID=39}; //测试
            //------------------------------------------------------------------------------------------------------------------------

            int initiateCount= applyService.LoadEntities(a => a.ApplicantId == userInfo.ID && (a.State == 0 || a.State == 1)).Count();//已经同意或拒绝的申请

            int receiveCount = applyService.LoadEntities(a => a.ApproverId == userInfo.ID && a.State > 1).Count();

            return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已接受消息", initiateMsgCount = initiateCount, receiveMsgCount = receiveCount }));

        }


        [HttpPost]
        public ActionResult GetInitiateList()
        {
            //string userInfoSID = Request.Cookies["userInfoSID"].Value;
            //Model.UserInfo userInfo = Common.SerializeHelper.DeserializeToObject<Model.UserInfo>(MemcacheHelper.Get(userInfoSID).ToString());

            Model.UserInfo userInfo = new Model.UserInfo() { ID = 39 }; //测试
                                                                        //------------------------------------------------------------------------------------------------------------------------
            var list = applyService.LoadEntities(a => a.ApplicantId == userInfo.ID);
            if (list != null)
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "加载完成", list = list }));
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "没有找到相关数据", list = list }));
        }
    }
}