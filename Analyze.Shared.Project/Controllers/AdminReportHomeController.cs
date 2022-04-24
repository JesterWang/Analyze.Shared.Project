using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    public class AdminReportHomeController : Controller
    {
        private IParInformationSummaryService _IParInformationSummaryService = null;

        public AdminReportHomeController(IParInformationSummaryService iParInformationSummaryService)
        {
            _IParInformationSummaryService = iParInformationSummaryService;
        }
        // GET: AdminReportHome
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 查询ParInformationSummary表分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ParPagingList(PageQuery query)
        {
            PageResult<ParInformationSummary> result = _IParInformationSummaryService.ParPagingList(query);
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// 修改ParInformationSummary的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(int tracking_id)
        {
            return PartialView("Update");
        }
    }
}