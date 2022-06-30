using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Bussiness.Services;
using Analyze.Shared.Common;
using Analyze.Shared.Common.Cache;
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
        private ISysUserService _ISysUserService = null;
        private IMenuPermissionService _IMenuPermissionService = null;
        public AccountController(ISysUserService iSysUserservice,IMenuPermissionService iMenuPermissionService) 
        {
            _ISysUserService = iSysUserservice;
            _IMenuPermissionService = iMenuPermissionService;
        }

        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]//提交登录
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)//触发实体验证--如果返回true,验证通过
            {
                CurrentUser currentUser = _ISysUserService.GetUser(user);
                if (currentUser != null)
                {
                    if (currentUser.status == "0")
                    {
                        ModelState.AddModelError("failed", "当前账号已禁用");
                        return View();
                    }
                    //写入Session
                    HttpContext.Session[CacheConstant.CacheCurrentUser] = currentUser;

                    //查询当前用户的菜单
                    List<Tuple<string, string, string, string>> tuples = new List<Tuple<string, string, string, string>>();
                    List<MenuPermission> menuinfoList = _IMenuPermissionService.GetSubmenue
                        (currentUser.id, out tuples);
                    currentUser.CurrentMenue = menuinfoList;
                    currentUser.TupMenue = tuples;
                    return base.Redirect("/Home/Index");
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

        //验证无权限提示
        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}