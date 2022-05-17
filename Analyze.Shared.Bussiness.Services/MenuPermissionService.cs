using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.User;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Services
{
    public class MenuPermissionService : BaseService, IMenuPermissionService
    {
        public MenuPermissionService(DbContext context)
            : base(context) 
        {
            
        }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dicmenue"></param>
        /// <returns></returns>
        public List<MenuPermission> GetSubmenue(int userId, out List<Tuple<string, string, string,string>> dicmenue) 
        {
            List<int> currentRoleIds = Context.Set<sys_user_role>().Where(c => c.user_id ==
                userId).Select(c=>c.role_id).Distinct().ToList();

            List<decimal> currentMenueIds = Context.Set<sys_role_menu_permission>().Where
                (c => currentRoleIds.Contains(c.role_id)).Select(c => c.menu_permission_id).Distinct().ToList();

            List<sys_menu_permission> sysMenus = Context.Set<sys_menu_permission>().Where
                (c => currentMenueIds.Contains(c.id)).ToList();

            var result = new List<MenuPermission>();
            dicmenue = sysMenus.Select(c => new Tuple<string, string, string,string>(c.id.ToString(),
                c.name, c.link_url,c.sort.ToString())).OrderBy(c=>c.Item4).ToList();

            List<MenuPermission> menues = GetSubmenueList(sysMenus,0,result);
            return result;
        }


        private List<MenuPermission> GetSubmenueList(List<sys_menu_permission> submenues, long parentid, List<MenuPermission> menus) 
        {
            var nextMenueList = submenues.Where(c => parentid == c.parent_id).OrderBy(c => c.sort);//OrderBy(c=>c.sort)对父菜单进行排序
            foreach (var menu in nextMenueList)
            {
                MenuPermission currentMenue = new MenuPermission()
                {
                    id = menu.id,
                    parent_id = menu.parent_id,
                    name = menu.name,
                    menu_code = menu.menu_code,
                    icon_url = menu.icon_url,
                    link_url = menu.link_url,
                    level = menu.level,
                    node_type = menu.node_type,
                    sort = menu.sort,
                    path = menu.path,
                };
                List<sys_menu_permission> nextSubmenues = submenues.Where(m => m.parent_id != parentid).ToList();
                GetSubmenueList(nextSubmenues, menu.id,currentMenue.Submenu);
                menus.Add(currentMenue);
            }
            return menus;
        }
    }
}
