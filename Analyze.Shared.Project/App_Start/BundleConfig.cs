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
                "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
                "~/Scripts/jquery-1.12.4.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.form.min-1.7.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                "~/Scripts/Datepicker/jquery-ui-1.10.4.custom.min.js",
                "~/Scripts/Datepicker/jquery-ui-timepicker-addon.js",
                "~/Scripts/Datepicker/jquery-ui-timepicker-zh-CN.js",
                "~/Scripts/Datepicker/jquery.ui.datepicker-zh-CN.js"));

            //--------------------------------------------------------------------

            bundles.Add(new ScriptBundle("~/Content/bootstrap").Include(
               "~/Content/bootstrap.min.css"));
            
            bundles.Add(new ScriptBundle("~/Plugins/css").Include(
                "~/Content/Plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/Plugins/simple-line-icons/css/simple-line-icons.min.css"));

            bundles.Add(new ScriptBundle("~/Layouts/css").Include(
            "~/Content/Layouts/layout/css/layout.min.css",
            "~/Content/Layouts/layout/themes/darkblue.min.css"));

            bundles.Add(new ScriptBundle("~/Datepicker/css").Include(
               "~/Content/Datepicker/jquery-ui.css",
               "~/Content/Datepicker/datediv.css"));
        }
    }
}