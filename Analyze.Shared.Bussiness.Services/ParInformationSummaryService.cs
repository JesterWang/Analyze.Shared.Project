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
        /// 查询整个信息汇总表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        //public List<ParInformationSummary> GetQuery() 
        //{
        //    List<ParInformationSummary> listParInformationSummary = new List<ParInformationSummary>();
        //    listParInformationSummary = Context.Set<par_information_summary>().Select(e => new ParInformationSummary
        //    {
        //        tracking_id = e.tracking_id,
        //        tracking_number = e.tracking_number,
        //        title = e.title,
        //        tracking_time = e.tracking_time,
        //        site = e.site,
        //        model = e.model,
        //        defect_rate = e.defect_rate,
        //        problem_description = e.problem_description,
        //        root_cause = e.root_cause,
        //        defect_img_url = e.defect_img_url,
        //        conclusion_img_url = e.conclusion_img_url,
        //        analysis_conclusion = e.analysis_conclusion,
        //        next_steps = e.next_steps,
        //        create_time = e.create_time,
        //        update_time = e.update_time,
        //        log_result = e.log_result
        //    }).ToList();
        //    return listParInformationSummary;
        //}

        /// <summary>
        /// 查询整个信息汇总表-分页
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        //public List<ParInformationSummary> GetQuery(int pageIndex, int pageSize) 
        //{
        //    List<ParInformationSummary> listParInformationSummary = new List<ParInformationSummary>();
        //    listParInformationSummary = Context.Set<par_information_summary>().Select(e => new ParInformationSummary
        //    {
        //        tracking_id = e.tracking_id,
        //        tracking_number = e.tracking_number,
        //        title = e.title,
        //        tracking_time = e.tracking_time,
        //        site = e.site,
        //        model = e.model,
        //        defect_rate = e.defect_rate,
        //        problem_description = e.problem_description,
        //        root_cause = e.root_cause,
        //        defect_img_url = e.defect_img_url,
        //        conclusion_img_url = e.conclusion_img_url,
        //        analysis_conclusion = e.analysis_conclusion,
        //        next_steps = e.next_steps,
        //        create_time = e.create_time,
        //        update_time = e.update_time,
        //        log_result = e.log_result
        //    }).OrderByDescending(e => e.tracking_id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //    return listParInformationSummary;
        //}
        
    }
}
