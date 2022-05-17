using Analyze.Shared.Common;
using Analyze.Shared.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Utility.Filters
{
    public class CustomCrumbsActionFilterAttribute:ActionFilterAttribute
    {
        //获取本次请求中菜单的标识
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Url.AbsoluteUri;
            Uri uri = new Uri(url);
            string query = uri.Query;
            string crumbs = UriHelper.GetUrlParameterValue(query,"crumbId");
            crumbs = HttpContext.Current.Server.UrlDecode(crumbs);
            filterContext.HttpContext.Session[CacheConstant.CacheCurrentCrumbs] = null;//面包屑
            if (!string.IsNullOrWhiteSpace(crumbs)) 
            {
                List<string> crumblist = crumbs.Split('_').Select(c => c.Trim()).ToList();
                filterContext.HttpContext.Session[CacheConstant.CacheCurrentCrumbs] = crumblist;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}