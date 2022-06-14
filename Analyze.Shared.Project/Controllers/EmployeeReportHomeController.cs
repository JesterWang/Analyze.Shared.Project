using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using Analyze.Shared.Project.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    
    public class EmployeeReportHomeController : BaseController
    {
        private IParInformationSummaryService _IParInformationSummaryService = null;
        public EmployeeReportHomeController(IParInformationSummaryService iParInformationSummaryService)
        {
            _IParInformationSummaryService = iParInformationSummaryService;
        }

        [CustomAuthorizeAttribute]
        [CustomCrumbsActionFilterAttribute]
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


    }
}