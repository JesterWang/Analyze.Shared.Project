using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using Analyze.Shared.Common.Extension;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;

namespace Analyze.Shared.Bussiness.Services
{
    public class ParInformationSummaryService : BaseService, IParInformationSummaryService
    {
        public ParInformationSummaryService(DbContext context): base(context) 
        {

        }

        /// <summary>
        /// 查询分页列表
        /// ParInformationSummaryDTO:展示到界面上的实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PageResult<ParInformationSummary> ParPagingList(PageQuery query) 
        {
            #region 查询关键字
            
            Expression<Func<par_information_summary, bool>> expression = null;
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                expression = expression.And(c => c.title.Contains(query.Search));
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

            PageResult<par_information_summary> pageResult = base.QueryPage(expression, query.PageSize, query.PageIndex, x => x.create_time, isAsc);
            PageResult<ParInformationSummary> pagelist = new PageResult<ParInformationSummary>
            {
                Total = pageResult.Total,
                Rows = Mapper.Map<List<par_information_summary>, List<ParInformationSummary>>(pageResult.Rows)
            };
            return pagelist;
        }

        /// <summary>
        /// 查询表
        /// </summary>
        /// <returns></returns>
        public List<ParInformationSummary> GetQueryEchart()
        {
            DateTime dtNextDay = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            DateTime dtLastDay = Convert.ToDateTime(DateTime.Now.AddDays(-90).ToString("yyyy-MM-dd"));
            List<ParInformationSummary> listParInformationSummary = new List<ParInformationSummary>();
            listParInformationSummary = Context.Set<par_information_summary>().Where(s=> s.tracking_time > dtLastDay && s.tracking_time < dtNextDay)
                .AsEnumerable().Select(e => new ParInformationSummary
                {
                    tracking_id = e.tracking_id,
                    tracking_number = e.tracking_number,
                    title = e.title,
                    tracking_time = e.tracking_time.ToString("yyyy-MM-dd HH:mm:ss"),
                    site = e.site,
                    model = e.model,
                    defect_rate = e.defect_rate,
                    isline = e.isline,
                    rd = e.rd,
                    issue_category = e.issue_category,
                    product_category = e.product_category,
                    status = e.status,
                    problem_description = e.problem_description,
                    root_cause = e.root_cause,
                    analysis_conclusion = e.analysis_conclusion,
                    next_steps = e.next_steps,
                    group_image = e.group_image,
                    create_owner = e.create_owner,
                    create_time = e.create_time.ToString("yyyy-MM-dd HH:mm:ss"),
                    update_time = e.update_time,
                    log_result = e.log_result
                }).ToList();
            return listParInformationSummary;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="tracking_id"></param>
        /// <returns></returns>
        public ParInformationSummary GetQueryReport(int tracking_id) 
        {
                        
            ParInformationSummary par = Context.Set<par_information_summary>().Where(e => e.tracking_id == tracking_id)
                .AsEnumerable().Select(e => new ParInformationSummary
                {
                    tracking_id = e.tracking_id,
                    tracking_number = e.tracking_number,
                    title = e.title,
                    tracking_time = e.tracking_time.ToString("yyyy-MM-dd HH:mm:ss"),
                    site = e.site,
                    model = e.model,
                    defect_rate = e.defect_rate,
                    isline=e.isline,
                    rd = e.rd,
                    issue_category = e.issue_category,
                    product_category = e.product_category,
                    status = e.status,
                    problem_description = e.problem_description,
                    root_cause = e.root_cause,
                    analysis_conclusion = e.analysis_conclusion,
                    next_steps = e.next_steps,
                    group_image=e.group_image,
                    create_owner=e.create_owner,
                    create_time = e.create_time.ToString("yyyy-MM-dd HH:mm:ss"),
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
        }

        /// <summary>
        /// 修改ParInformationSummary表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public bool Update(ParInformationSummary parInformationSummary) 
        {
            par_information_summary parContext = new par_information_summary()
            {
                tracking_id = parInformationSummary.tracking_id,
                tracking_number = parInformationSummary.tracking_number,
                title = parInformationSummary.title,
                tracking_time = Convert.ToDateTime(parInformationSummary.tracking_time),
                site = parInformationSummary.site,
                model = parInformationSummary.model,
                defect_rate = parInformationSummary.defect_rate,
                isline=parInformationSummary.isline,
                rd=parInformationSummary.rd,
                issue_category = parInformationSummary.issue_category,
                product_category = parInformationSummary.product_category,
                status = parInformationSummary.status,
                problem_description = parInformationSummary.problem_description,
                root_cause = parInformationSummary.root_cause,
                analysis_conclusion = parInformationSummary.analysis_conclusion,
                next_steps = parInformationSummary.next_steps,
                group_image = parInformationSummary.group_image,
                create_owner=parInformationSummary.create_owner,
                update_time = DateTime.Now,
                log_result = parInformationSummary.log_result
            };
            Context.Set<par_information_summary>().Attach(parContext);
            Context.Entry<par_information_summary>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 添加ParInformationSummary表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        public bool Insert(ParInformationSummary parInformationSummary) 
        {
            par_information_summary parContext = new par_information_summary()
            {
                tracking_number=parInformationSummary.tracking_number,
                title = parInformationSummary.title,
                tracking_time = Convert.ToDateTime(parInformationSummary.tracking_time),
                site = parInformationSummary.site,
                model = parInformationSummary.model,
                defect_rate = parInformationSummary.defect_rate,
                isline = parInformationSummary.isline,
                rd = parInformationSummary.rd,
                issue_category = parInformationSummary.issue_category,
                product_category = parInformationSummary.product_category,
                status = parInformationSummary.status,
                problem_description = parInformationSummary.problem_description,
                root_cause = parInformationSummary.root_cause,
                analysis_conclusion = parInformationSummary.analysis_conclusion,
                next_steps = parInformationSummary.next_steps,
                create_owner = parInformationSummary.create_owner
            };
            Context.Set<par_information_summary>().Add(parContext);
            Context.SaveChanges();
            return true;
        }
    }
}
