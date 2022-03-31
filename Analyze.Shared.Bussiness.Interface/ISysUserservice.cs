using Analyze.Shared.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface ISysUserservice : IBaseService
    {
        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        CurrentUser GetUser(LoginUser loginUser);
    }
}
