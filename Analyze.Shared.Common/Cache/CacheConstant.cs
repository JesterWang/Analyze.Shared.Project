using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Cache
{
    public class CacheConstant
    {
        /// <summary>
        /// 当前用户信息
        /// 1.包含了用户基本信息
        /// 2.包含了用户权限内包含的菜单
        /// </summary>
        public static string CacheCurrentUser = "CurrentUser";

        /// <summary>
        /// 当前访问的Url地址
        /// </summary>
        public static string CacheCurrentUrl = "CurrentUrl";

        /// <summary>
        /// 当前用户的面包屑
        /// </summary>
        public static string CacheCurrentCrumbs = "CurrentCrumbs";

        /// <summary>
        /// 当前用户的菜单数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string CacheCurrentMenue(int userId) 
        {
            return "CurrentMenue_" + userId;
        }
        /// <summary>
        /// 在线人数统计
        /// </summary>
        public static string CacheOnLineUserCount = "OnLineUserCount";
    }
}
