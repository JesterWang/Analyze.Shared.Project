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
    public class SysUserService : BaseService,ISysUserService
    {
        public SysUserService(DbContext context):base(context) 
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
                    id = e.id,
                    username = e.username,
                    password = e.password,
                    employee_name = e.employee_name,
                    employee_itcode = e.employee_itcode,
                    role_id = e.role_id,
                    job_id=e.job_id,
                    dept_id=e.dept_id,
                    status = e.status,
                }).FirstOrDefault();
            return user;
        }
    }
}
