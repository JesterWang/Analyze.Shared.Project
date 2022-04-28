using Analyze.Shared.Common.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IParFaeService : IBaseService
    {
        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        ParFae GetQueryReport(int tracking_id);

        /// <summary>
        /// 修改ME问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool GetUpdateReport(ParFae parFae);
    }
}
