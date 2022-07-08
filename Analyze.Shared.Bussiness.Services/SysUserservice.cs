using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.User;
using Analyze.Shared.Common.Extension;
using Analyze.Shared.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
                    sex=e.sex,
                    tel=e.tel,
                    email=e.email,
                    job_id=e.job_id,
                    dept_id=e.dept_id,
                    status = e.status
                }).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool GetUserIs(string username)
        {
            CurrentUser user = Context.Set<sys_user>().Where(e => e.username == username)
                .Select(e => new CurrentUser
                {
                    id = e.id,
                    username = e.username,
                    password = e.password,
                    employee_name = e.employee_name,
                    employee_itcode = e.employee_itcode,
                    sex = e.sex,
                    tel = e.tel,
                    email = e.email,
                    job_id = e.job_id,
                    dept_id = e.dept_id,
                    status = e.status
                }).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 查询分页列表
        /// ParInformationSummaryDTO:展示到界面上的实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PageResult<CurrentUserView> ParPagingList(PageQuery query)
        {
            #region 查询关键字

            Expression<Func<view_user, bool>> expression = null;
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                expression = expression.And(c => c.employee_name.Contains(query.Search));
            }
            #endregion
            #region 排序类型
            bool isAsc = false;
            if (query.Order.Equals("asc"))
            {
                isAsc = false;//降序
            }
            #endregion

            #region 排序字段

            #endregion

            PageResult<view_user> pageResult = base.QueryPage(expression, query.PageSize, query.PageIndex, x => x.create_time, isAsc);
            PageResult<CurrentUserView> pagelist = new PageResult<CurrentUserView>
            {
                Total = pageResult.Total,
                Rows = Mapper.Map<List<view_user>, List<CurrentUserView>>(pageResult.Rows)
            };
            return pagelist;
        }

        /// <summary>
        /// 添加CurrentUser表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public bool Insert(CurrentUserDTO currentUser)
        {
            sys_user userContext = new sys_user()
            {
                username = currentUser.username,
                password=currentUser.password.ToMd5(),//MD5加密
                employee_name=currentUser.employee_name,
                employee_itcode=currentUser.employee_itcode,
                job_id=currentUser.job_id,
                dept_id=currentUser.dept_id,
                status="1"
            };
            Context.Set<sys_user>().Add(userContext);
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 修改CurrentUser表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public bool Update(CurrentUserDTO currentUser) 
        {
            sys_user userContext = new sys_user()
            {
                id=currentUser.id,
                username = currentUser.username,
                password=currentUser.password,
                employee_name = currentUser.employee_name,
                employee_itcode = currentUser.employee_itcode,
                sex=currentUser.sex,
                tel=currentUser.tel,
                email=currentUser.email,
                job_id = currentUser.job_id,
                dept_id = currentUser.dept_id,
                status = currentUser.status,
                update_time=DateTime.Now
            };
            Context.Set<sys_user>().Attach(userContext);
            Context.Entry<sys_user>(userContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除CurrentUser表用户信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public AjaxResult Delete(int id) 
        {
            Delete<sys_user>(id);
            return new AjaxResult()
            {
                Success = true,
                Message = "删除成功！"
            };
        }

        /// <summary>
        /// 修改CurrentUser表用户密码
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public bool ResetPassword(string password,int id)
        {
            password = password.ToMd5();
            string sql = string.Format("update sys_user set password='{0}' where id='{1}'", password, id);
            Context.Database.ExecuteSqlCommand(sql);
            Context.SaveChanges();
            return true;
        }


        /// <summary>
        /// 查询职位:SysJob表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public List<SysJob> GetQuerySysJob()
        {
            List<SysJob> listSysJob = new List<SysJob>();
            listSysJob = Context.Set<sys_job>()
                .Select(e => new SysJob
                {
                    id = e.id,
                    job=e.job
                }).OrderBy(c=>c.id).ToList();
            return listSysJob;
        }

        /// <summary>
        /// 查询组织:SysDept表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public List<SysDept> GetQuerySysDept()
        {
            List<SysDept> listSysDept = new List<SysDept>();
            listSysDept = Context.Set<sys_dept>()
                .Select(e => new SysDept
                {
                    id = e.id,
                    dname_short = e.dname_short
                }).OrderBy(c => c.id).ToList();
            return listSysDept;
        }
    }
}
