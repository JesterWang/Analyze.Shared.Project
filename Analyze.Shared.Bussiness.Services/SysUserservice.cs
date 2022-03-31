using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common;
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
    public class SysUserservice : BaseService,ISysUserservice
    {
        public SysUserservice(DbContext context):base(context) 
        {

        }

        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public CurrentUser GetUser(LoginUser loginUser) 
        {
            string passwordMd5 = loginUser.password.ToMd5();
            CurrentUser user = Context.Set<sys_user>().Where(e => e.username == loginUser.username && e.password == passwordMd5)
                .Select(e => new CurrentUser 
                { 
                    Id = e.id,
                    username = e.username,
                    password = e.password,
                    emp_id = e.emp_id,
                    role_id = e.role_id,
                    status = e.status,
                    create_time = e.create_time
                }).FirstOrDefault();
            return user;
        }
    }
}
