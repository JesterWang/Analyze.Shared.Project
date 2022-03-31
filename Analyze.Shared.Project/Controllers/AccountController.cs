using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Bussiness.Services;
using Analyze.Shared.Common;
using Analyze.Shared.Common.User;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Analyze.Shared.Project.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]//返回一个页面：这个页面是用来展示登录的页面
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]//提交登录--开始登录的时候，需要去处理的业务逻辑
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

                
                ISysUserservice sysUserservice = new SysUserservice(new efc_db_01_DBContext());
                CurrentUser currentUser = sysUserservice.GetUser(user);
                if (currentUser != null)
                {
                    {
                        //写入Session
                        HttpContext.Session["CurrentUser"] = currentUser;
                    }
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
    }
}