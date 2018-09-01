using OA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class ApplyController : BaseController
    {
        IBLL.IApplyService applyService = ServiceFactory.SevSession.GetApplyService();
        // GET: Apply
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetTabTips()
        {
            Model.UserInfo userInfo = null;//GetActiveUserInfo();
            userInfo = new Model.UserInfo() { ID = 39 }; //测试



            //------------------------------------------------------------------------------------------------------------------------

            int initiateCount = applyService.LoadEntities(a => a.ApplicantId == userInfo.ID && (a.State == 0 || a.State == 1)).Count();//已经同意或拒绝的申请

            int receiveCount = applyService.LoadEntities(a => a.ApproverId == userInfo.ID && a.State > 1).Count();

            return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已接受消息", initiateMsgCount = initiateCount, receiveMsgCount = receiveCount }));

        }


        [HttpPost]
        public ActionResult GetInitiateList()
        {
            Model.UserInfo userInfo = null;//GetActiveUserInfo();
            userInfo = new Model.UserInfo() { ID = 39 }; //测试



            //------------------------------------------------------------------------------------------------------------------------
            var list = applyService.LoadEntities(a => a.ApplicantId == userInfo.ID).OrderBy(a=>a.State);
            if (list != null)
            {
                return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "加载完成", list = list }));
            }
            return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "没有找到相关数据", list = list }));
        }

        [HttpPost]
        public ActionResult GetReceiveList()
        {
            Model.UserInfo userInfo = null;//GetActiveUserInfo();
            userInfo = new Model.UserInfo() { ID = 39 }; //测试



            var list = applyService.LoadEntities(a => a.ApproverId == userInfo.ID).OrderByDescending(a => a.State);

            

            return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "加载完成", list = list }));

        }

        [HttpPost]
        public ActionResult HandleApply(Model.Apply apply)
        {
            Model.UserInfo userInfo = null;//GetActiveUserInfo();
            userInfo = new Model.UserInfo() { ID = 39 }; //测试



            if (apply.ApproverId == userInfo.ID)
            {
                applyService.HandleApply(apply.Id, Convert.ToInt32(apply.State), apply.Remark2);
            }
            else return Content(SerializeHelper.SerializeToString(new { state = 1, msg = "处理失败" }));
            return Content(SerializeHelper.SerializeToString(new { state = 0, msg = "已处理" }));
        }

        //[HttpGet]
        //public ActionResult Application()
        //{
               
        //}
    }
}