using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Utility.Filters
{
    public class CustomAuthorizeAttribute : FilterAttribute,IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext) 
        {
            //验证是否登录过
            object ouser = filterContext.HttpContext.Session["CurrentUser"];
            if (ouser == null || (ouser is CurrentUser) == false)
            {
                ResponseResult(filterContext);
            }
            else 
            {
               
            }
        }

        /// <summary>
        /// 没有登录的响应事件
        /// </summary>
        /// <param name="filterContext"></param>
        private static void ResponseResult(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())//Ajax请求
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new AjaxResult()
                    {
                        Success = false,
                        Message = "没有登录，无法获取数据"
                    }
                };
            }
            else//非Ajax请求 
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}