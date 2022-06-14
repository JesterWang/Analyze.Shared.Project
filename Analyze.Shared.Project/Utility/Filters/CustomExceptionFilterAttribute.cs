using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Utility.Filters
{
    //public class CustomExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    //{
    //    //log4net组件,用于日志记录。
    //     static readonly ILog log = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));
    //     public void OnException(ExceptionContext filterContext)
    //     {
    //         //对捕获到的异常信息进行日志记录,方便开发人员排查问题。
    //         log.Error("应用程序异常", filterContext.Exception);
 
    //         //跳转到自定义的错误页,增强用户体验。
    //         ActionResult result = new ViewResult() { ViewName = "Error" };
    //         filterContext.Result = result;
    //         //异常处理结束后,一定要将ExceptionHandled设置为true,否则仍然会继续抛出错误。
    //         filterContext.ExceptionHandled = true;
    //     }
    //}
}