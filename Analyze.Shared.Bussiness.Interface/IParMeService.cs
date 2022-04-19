using Analyze.Shared.Common.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IParMeService : IBaseService
    {
        /// <summary>
        /// 查询ME问题分析报告
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        ParMe GetQueryReport(int tracking_id);
    }
}
