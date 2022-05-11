using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Bussiness.Services;
using Analyze.Shared.Common;
using Analyze.Shared.Common.User;
using Analyze.Shared.DataAccess;
using Analyze.Shared.Project.Utility;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Analyze.Shared.Project.Controllers
{
    public class AccountController : Controller
    {
        private ISysUserService _ISysUserservice = null;
        public AccountController(ISysUserService iSysUserservice) 
        {
            _ISysUserservice = iSysUserservice;
        }
        [HttpGet]//返回登录页
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]//提交登录
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)//触发实体验证--如果返回true,验证通过
            {

                //连接数据库查询--EF6
                #region 直接查询
                //using (efc_db_01_DBContext context = new efc_db_01_DBContext())
                //{
                //   //密码明文MD5,通过MD5之后的数据做查询
                //   string md5password = user.password.ToMd5();
                //   sys_user currentUser = context.Set<sys_user>().FirstOrDefault(e => e.username == user.username && e.password == md5password);
                //   if (currentUser != null)
                //   {
                //       {
                //           //写入Session
                //           HttpContext.Session["CurrentUser"] = currentUser;
                //       }
                //       return base.Redirect("/Home/Index");
                //   }
                //   else
                //   {
                //       ModelState.AddModelError("failed", "用户名或者密码错误");
                //       return View();
                //   }
                //} 
                #endregion

                //ISysUserservice sysUserservice = new SysUserservice(new efc_db_01_DBContext());

                {
                    //断开对细节的依赖--通过IOC容器来创建Unity
                    //IUnityContainer _Container = new UnityContainer();
                    //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                    //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory+"CfgFiles\\Unity.Config");
                    //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,ConfigurationUserLevel.None);
                    //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection
                    //    (UnityConfigurationSection.SectionName);
                    //section.Configure(_Container, "AnalyzeContainer");
                    
                    //ISysUserservice sysUserservice = _Container.Resolve<ISysUserservice>();
                }

                //IUnityContainer unityContainer = CustomDIFactory.GetContainer();
                //ISysUserservice sysUserservice = unityContainer.Resolve<ISysUserservice>();
                CurrentUser currentUser = _ISysUserservice.GetUser(user);
                if (currentUser != null)
                {
                    //写入Session
                    HttpContext.Session["CurrentUser"] = currentUser;

                    //查询当前用户的菜单
                    //List<Tuple<string, string, string>> tuples = new List<Tuple<string, string, string>>();
                    //List<>

                    return base.Redirect("/AdminReportHome/Index");
                }
                else
                {
                    ModelState.AddModelError("failed", "用户名或者密码错误");
                    return View();
                }
            }
            else 
            {
                return View();
            }
        }

        //登出
        public ActionResult LoginOut() 
        {
            HttpContext.Session.Clear();
            return base.Redirect("/Account/Login");
        }
    }
}