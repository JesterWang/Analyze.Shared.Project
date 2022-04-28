using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    public class AdminReportHomeController : BaseController
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
            par_information_summary par_information_summary = _IParInformationSummaryService.Find<par_information_summary>(tracking_id);
            ParInformationSummary parInformationSummary = Mapper.Map<par_information_summary,ParInformationSummary>(par_information_summary);
            return PartialView("Update", parInformationSummary);
        }

        [HttpPost]
        public ActionResult Update(ParInformationSummary parInformationSummary)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //验证
            if (ModelState.IsValid)
            {
                string log_result = GetUserName() + GetUserEmplyeeName();
                bool bResult = _IParInformationSummaryService.Update(parInformationSummary, log_result);
                if (bResult) 
                {
                    jsonResult.Data = new AjaxResult()
                    {
                        Success = true,
                        Message = "操作成功"
                    }; 
                }
                else
                {
                    jsonResult.Data = new AjaxResult()
                    {
                        Success = false,
                        Message = "操作失败"
                    };
                }
            }
            else 
            {
                jsonResult.Data = new AjaxResult()
                {
                    Success = false,
                    Message = "操作失败"
                };
            }

            return jsonResult;
        }
    }
}