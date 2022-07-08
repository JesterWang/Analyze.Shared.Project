using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
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

namespace Analyze.Shared.Project.Areas.SystemManage.Controllers
{
    [CustomAuthorizeAttribute]
    public class UserController : BaseController
    {
        private ISysUserService _ISysUserService = null;
        public UserController(ISysUserService iSysUserService)
        {
            _ISysUserService = iSysUserService;
        }

        // GET: SystemManage/User
        [CustomCrumbsActionFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询CurrentUserDTO表分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ParPagingList(PageQuery query)
        {
            PageResult<CurrentUserView> result = _ISysUserService.ParPagingList(query);
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// 添加CurrentUser的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Insert()
        {
            SelectItemListMethod();
            return PartialView("Insert");
        }

        /// <summary>
        /// 添加CurrentUser的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(string username, string password, string employee_name,
            string employee_itcode, byte job_id, decimal dept_id)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //验证
            if (username != "" && job_id != 0 && dept_id != 0)
            {
                //判断用户名是否存在
                if (_ISysUserService.GetUserIs(username) == true)
                {
                    jsonResult.Data = new AjaxResult()
                    {
                        Success = false,
                        Message = "用户名已存在！"
                    };
                    return jsonResult;
                }

                CurrentUserDTO currentUser = new CurrentUserDTO()
                {
                    username = username,
                    password = password,
                    employee_name = employee_name,
                    employee_itcode = employee_itcode,
                    job_id = job_id,
                    dept_id = dept_id,
                };
                bool bResult = _ISysUserService.Insert(currentUser);
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
                    return jsonResult;
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
        /// 修改CurrentUserDTO的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(int id)
        {
            SelectItemListMethod();
            sys_user sys_user = _ISysUserService.Find<sys_user>(id);
            CurrentUserDTO currentUserDTO = Mapper.Map<sys_user,CurrentUserDTO>(sys_user);
            return PartialView("Update", currentUserDTO);
        }

        /// <summary>
        /// 修改CurrentUserDTO的页面
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(CurrentUserDTO currentUserDTO)
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
        /// 删除CurrentUserDTO的单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonResult.Data = _ISysUserService.Delete(id);
            return jsonResult;
        }

        /// <summary>
        /// 重置CurrentUserDTO的单个用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PasswordReset(int id)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (ModelState.IsValid)
            {
                string _password = "123456";
                bool bResult = _ISysUserService.ResetPassword(_password,id);
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