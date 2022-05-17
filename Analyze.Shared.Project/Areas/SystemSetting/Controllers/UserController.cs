using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.User;
using Analyze.Shared.DataAccess;
using Analyze.Shared.Project.Controllers;
using Analyze.Shared.Project.Utility.Filters;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Areas.SystemSetting.Controllers
{
    [CustomAuthorizeAttribute]
    public class UserController : BaseController
    {
        private ISysUserService _ISysUserService = null;
        public UserController(ISysUserService iSysUserService)
        {
            _ISysUserService = iSysUserService;
        }

        // GET: SystemSetting/User
        [CustomCrumbsActionFilterAttribute]
        public ActionResult Index()
        {
            SelectItemListMethod();

            int id = GetUserId();
            sys_user sys_user = _ISysUserService.Find<sys_user>(id);
            CurrentUserDTO currentUserDTO = Mapper.Map<sys_user, CurrentUserDTO>(sys_user);
            return View(currentUserDTO);
        }

        // Post: SystemSetting/User
        [HttpPost]
        public ActionResult Edit(CurrentUserDTO currentUserDTO)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //验证
            if (ModelState.IsValid)
            {
                bool bResult = _ISysUserService.Update(currentUserDTO);
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

        /// <summary>
        /// 下拉框数据绑定事件
        /// </summary>
        private void SelectItemListMethod()
        {
            //职位下拉框绑定数据
            var jopSelectItemList = new List<SelectListItem>() { 
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var jobselectList = new SelectList(_ISysUserService.GetQuerySysJob(), "id", "job");
            jopSelectItemList.AddRange(jobselectList);
            ViewBag.sysjob = jopSelectItemList;

            //组织下拉框绑定数据
            var deptSelectItemList = new List<SelectListItem>() { 
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var deptselectList = new SelectList(_ISysUserService.GetQuerySysDept(), "id", "dname_short");
            deptSelectItemList.AddRange(deptselectList);
            ViewBag.sysdept = deptSelectItemList;
        }
    }
}