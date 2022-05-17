using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Project.Controllers;
using Analyze.Shared.Project.Utility.Filters;
using Analyze.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Areas.SystemSetting.Controllers
{
    [CustomAuthorizeAttribute]
    public class PasswodModifyController : BaseController
    {
        private ISysUserService _ISysUserService = null;
        public PasswodModifyController(ISysUserService iSysUserService)
        {
            _ISysUserService = iSysUserService;
        }

        // GET: SystemSetting/PasswodModify
        [CustomCrumbsActionFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifyPassword(string oldPassword, string newPassword, string newRePassword)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (ModelState.IsValid)
            {
                if (oldPassword != string.Empty && newPassword != string.Empty && newRePassword != string.Empty) 
                {
                    string password = GetUser().password;//当前用户密码
                    int userId = GetUserId();//当前用户ID
                    //转换成MD5再比较
                    string _oldPassword = SecurityMgr.ToMd5(oldPassword);
                    string _newPassword = SecurityMgr.ToMd5(newPassword);
                    string _newRePassword = SecurityMgr.ToMd5(newRePassword);

                    
                    if (_oldPassword != password)
                    {
                        jsonResult.Data = new AjaxResult()
                        {
                            Success = false,
                            Message = "旧密码输入错误"
                        };
                        return jsonResult;
                    }

                    if (_newRePassword != _newPassword)
                    {
                        jsonResult.Data = new AjaxResult()
                        {
                            Success = false,
                            Message = "确认密码与新密码不一致"
                        }; 
                        return jsonResult;
                    }

                    if (_newRePassword == _oldPassword)
                    {
                        jsonResult.Data = new AjaxResult()
                        {
                            Success = false,
                            Message = "新密码不能与旧密码一致"
                        };
                        return jsonResult;
                    }

                    bool bResult = _ISysUserService.ResetPassword(newRePassword, userId);
                    if (bResult)
                    {
                        jsonResult.Data = new AjaxResult()
                        {
                            Success = true,
                            Message = "操作成功"
                        };
                        HttpContext.Session.Clear();
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
                        Message = "操作失败，密码填写不完整"
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