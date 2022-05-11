using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using Analyze.Shared.Project.Utility.Filters;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    [CustomAuthorizeAttribute]
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
            if (GetUser()!= null) 
            {
                string _username = GetUserName();
                ViewData["username"] = _username;
                string _role_id = GetUser().role_id.ToString();
                ViewData["role_id"] = _role_id;
                ViewData["visitcount"] = HttpContext.Application["OnLineUserCount"].ToString();
            }
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
        public ActionResult Insert()
        {
            return PartialView("Insert");
        }

        /// <summary>
        /// 添加ParInformationSummary的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(string title, string tracking_time, string site, string model, string defect_rate, string isline
            , string problem_description, string root_cause, string analysis_conclusion, string next_steps)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //验证
            if (title != "" || tracking_time != "" || site != "" || model != "" || defect_rate != "")
            {
                ParInformationSummary parInformationSummary = new ParInformationSummary()
                {
                    tracking_number=DateTime.Now.ToString("yyyyMMddHHmmss"),
                    title = title,
                    tracking_time = Convert.ToDateTime(tracking_time),
                    site = site,
                    model = model,
                    defect_rate = defect_rate,
                    isline = isline,
                    problem_description = problem_description,
                    root_cause = root_cause,
                    analysis_conclusion = analysis_conclusion,
                    next_steps = next_steps
                };
                bool bResult = _IParInformationSummaryService.Insert(parInformationSummary);
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
                    Message = "操作失败,必填项必须填写完整！"
                };
            }

            return jsonResult;
        }

        /// <summary>
        /// 修改ParInformationSummary的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult Update(int tracking_id)
        //{
        //    par_information_summary par_information_summary = _IParInformationSummaryService.Find<par_information_summary>(tracking_id);
        //    ParInformationSummary parInformationSummary = Mapper.Map<par_information_summary,ParInformationSummary>(par_information_summary);
        //    return PartialView("Update", parInformationSummary);
        //}

        //[HttpPost]
        //public ActionResult Update(ParInformationSummary parInformationSummary)
        //{
        //    JsonResult jsonResult = new JsonResult();
        //    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    //验证
        //    if (ModelState.IsValid)
        //    {
        //        string log_result = GetUserName() + GetUserEmplyeeName();
        //        bool bResult = _IParInformationSummaryService.Update(parInformationSummary, log_result);
        //        if (bResult) 
        //        {
        //            jsonResult.Data = new AjaxResult()
        //            {
        //                Success = true,
        //                Message = "操作成功"
        //            }; 
        //        }
        //        else
        //        {
        //            jsonResult.Data = new AjaxResult()
        //            {
        //                Success = false,
        //                Message = "操作失败"
        //            };
        //        }
        //    }
        //    else 
        //    {
        //        jsonResult.Data = new AjaxResult()
        //        {
        //            Success = false,
        //            Message = "操作失败"
        //        };
        //    }

        //    return jsonResult;
        //}
    }
}