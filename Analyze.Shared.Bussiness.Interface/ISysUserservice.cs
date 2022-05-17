using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface ISysUserService : IBaseService
    {
        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        CurrentUser GetUser(LoginUser loginUser);

        /// <summary>
        /// 查询分页列表
        ///CurrentUserDTO:展示到界面上的实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PageResult<CurrentUserDTO> ParPagingList(PageQuery query);

        /// <summary>
        /// 添加CurrentUser表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        bool Insert(CurrentUserDTO CurrentUser);

        /// <summary>
        /// 修改CurrentUser表用户信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        bool Update(CurrentUserDTO currentUser);

        /// <summary>
        /// 删除CurrentUser表用户信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        AjaxResult Delete(int id);

        /// <summary>
        /// 修改CurrentUser表用户密码
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        bool ResetPassword(string password,int id);

         /// <summary>
        /// 查询职位:SysJob表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        List<SysJob> GetQuerySysJob();

        /// <summary>
        /// 查询组织:SysDept表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        List<SysDept> GetQuerySysDept();
    }
}
