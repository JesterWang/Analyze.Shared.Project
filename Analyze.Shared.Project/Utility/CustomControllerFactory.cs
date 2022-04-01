using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Analyze.Shared.Project.Utility
{
    /// <summary>
    /// 定义了一个控制器工厂：
    /// 把这个控制器工厂设置到MVC框架中，在创建控制器的实例的时候，就会执行这个工厂中的方法，自定义控制器如何创建
    /// </summary>
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IUnityContainer unityContainer = CustomDIFactory.GetContainer();
            object oInstance = unityContainer.Resolve(controllerType);
            return (IController)oInstance;
        }
    }
}