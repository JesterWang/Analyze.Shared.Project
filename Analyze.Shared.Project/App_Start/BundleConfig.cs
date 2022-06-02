using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Analyze.Shared.Project.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
                "~/Scripts/jquery-1.12.4.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.form-1.7.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            //--------------------------------------------------------------------

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
               "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Plugins/css").Include(
                "~/Content/Plugins/font-awesome/css/font-awesome.css",
                "~/Content/Plugins/simple-line-icons/css/simple-line-icons.css"));

            bundles.Add(new StyleBundle("~/Layouts/css").Include(
            "~/Content/Layouts/layout/css/layout.css",
            "~/Content/Layouts/layout/themes/darkblue.css"));
        }
    }
}