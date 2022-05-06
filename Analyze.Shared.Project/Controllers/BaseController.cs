using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Report;
using Analyze.Shared.Common.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    
    public class BaseController : Controller
    {
        
        /// <summary>
        /// 获取当前用户Id
        /// </summary>
        /// <returns></returns>
        public int GetUserId()
        {
            if (Session["CurrentUser"] != null)
            {
                CurrentUser user = (CurrentUser)Session["CurrentUser"];
                return user.id;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取当前用户名
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            if (Session["CurrentUser"] != null)
            {
                CurrentUser user = (CurrentUser)Session["CurrentUser"];
                return user.username;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取当前用户真实姓名
        /// </summary>
        /// <returns></returns>
        public string GetUserEmplyeeName()
        {
            if (Session["CurrentUser"] != null)
            {
                CurrentUser user = (CurrentUser)Session["CurrentUser"];
                return user.emplyee_name;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns>用户信息</returns>
        public CurrentUser GetUser()
        {
            if (Session["CurrentUser"] != null)
            {
                return (CurrentUser)Session["CurrentUser"];
            }
            return null;
        }

        /// <summary>
        /// 检查SQL语句合法性
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ValidateSQL(string sql, ref string msg)
        {
            if (sql.ToLower().IndexOf("delete") > 0)
            {
                msg = "查询参数中含有非法语句DELETE";
                return false;
            }
            if (sql.ToLower().IndexOf("update") > 0)
            {
                msg = "查询参数中含有非法语句UPDATE";
                return false;
            }

            if (sql.ToLower().IndexOf("insert") > 0)
            {
                msg = "查询参数中含有非法语句INSERT";
                return false;
            }
            return true;
        }
    }
}