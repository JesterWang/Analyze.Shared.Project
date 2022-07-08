using Analyze.Shared.Common.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IParMaterialsService : IBaseService
    {
        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        List<ParMaterials> GetQueryReport(int tracking_id);

        /// <summary>
        /// 修改Materials问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool GetUpdateReport(ParMaterials parMaterials);

        /// <summary>
        /// 添加Materials问题分析报告
        /// </summary>
        /// <param name="parMaterials"></param>
        /// <returns></returns>
        bool Insert(ParMaterials parMaterials);

        /// <summary>
        /// 修改Materials问题分析报告
        /// </summary>
        /// <param name="parMaterials"></param>
        /// <returns></returns>
        bool Update(ParMaterials parMaterials);

        /// <summary>
        /// 删除Materials信息-单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
