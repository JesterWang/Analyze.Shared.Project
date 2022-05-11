using Analyze.Shared.Project.App_Start;
using Analyze.Shared.Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Analyze.Shared.Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //给MVC框架设置一个控制器工厂
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());

            //让AutoMapperConfig配置生效
            AutoMapper.Mapper.Initialize(config=>{
                config.AddProfile(new AutoMapperConfig());
            });

            //访问量统计
            Application["OnLineUserCount"] = 0;
            AreaRegistration.RegisterAllAreas();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnLineUserCount"] = Convert.ToInt32(Application["OnLineUserCount"]) + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["OnLineUserCount"] = Convert.ToInt32(Application["OnLineUserCount"]) - 1;
            //Application.UnLock();
        }
    }
}
