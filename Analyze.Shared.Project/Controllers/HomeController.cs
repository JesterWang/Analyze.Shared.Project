using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Chart;
using Analyze.Shared.Project.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    public class HomeController : BaseController
    {
        private IParInformationSummaryService _IParInformationSummaryService = null;
        public HomeController(IParInformationSummaryService iParInformationSummaryService)
        {
            _IParInformationSummaryService = iParInformationSummaryService;
        }

        [CustomAuthorizeAttribute]
        [CustomCrumbsActionFilterAttribute]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 首页-统计图
        /// </summary>
        /// <returns></returns>
        public ActionResult Echarts()
        {
            var grpBalance = _IParInformationSummaryService.GetQueryEchart().GroupBy(m => new { m.issue_category }).Select(t => new HomeChart
            {
                issue_category = t.Key.issue_category,
                count1 = t.Where(s => s.status == "Ongoing").Sum(s => 1),
                count2 = t.Where(s => s.status == "Tracking").Sum(s => 1),
                count3 = t.Where(s => s.status == "Closed").Sum(s => 1)
            }).ToList();

            //注意这里要返回JSON数据而不是view视图 
            return Json(grpBalance, JsonRequestBehavior.AllowGet);
        }

    }
}