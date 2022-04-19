using Analyze.Shared.Common.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    public interface IParFileService : IBaseService
    {
        /// <summary>
        /// 查询文件列表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        List<ParFileUpload> GetQuery(int tracking_id, int category_id);

        /// <summary>
        /// 添加文件信息-单条
        /// </summary>
        /// <param name="parFileUpload"></param>
        /// <returns></returns>
        bool GetInsert(ParFileUpload parFileUpload);

        /// <summary>
        /// 删除文件信息-单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool GetDelete(int id);
    }
}
