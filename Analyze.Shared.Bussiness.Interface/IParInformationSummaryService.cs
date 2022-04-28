using Analyze.Shared.Common.Query;
using Analyze.Shared.Common.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IParInformationSummaryService : IBaseService
    {
        /// <summary>
        /// 查询分页列表
        ///ParInformationSummary:展示到界面上的实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PageResult<ParInformationSummary> ParPagingList(PageQuery query);

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="tracking_id"></param>
        /// <returns></returns>
        ParInformationSummary GetQueryReport(int tracking_id);

        /// <summary>
        /// 修改ParInformationSummary表信息
        /// </summary>
        /// <param name="parInformationSummary"></param>
        /// <returns></returns>
        bool Update(ParInformationSummary parInformationSummary, string log_result);
    }
}
