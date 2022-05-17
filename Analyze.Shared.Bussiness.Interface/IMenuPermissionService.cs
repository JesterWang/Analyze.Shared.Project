using Analyze.Shared.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IMenuPermissionService : IBaseService
    {
        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dicmenue"></param>
        /// <returns></returns>
        List<MenuPermission> GetSubmenue(int userId, out List<Tuple<string, string, string, string>> dicmenue); 
    }
}
