using Analyze.Shared.Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Analyze.Shared.Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //给MVC框架设置一个控制器工厂
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
