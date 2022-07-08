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
        /// 查询视图报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        List<ViewParFile> GetQueryView(int tracking_id, int category_id_1, int category_id_2, int category_id_3, int category_id_4);

        /// <summary>
        /// 查询视图报表-1个分类
        /// </summary>
        /// <param name="tracking_id"></param>
        /// <param name="category_id_1"></param>
        /// <returns></returns>
        List<ViewParFile> GetQueryView_1(int tracking_id, int category_id_1);


        /// <summary>
        /// 查询视图报表-5个分类
        /// </summary>
        /// <param name="tracking_id"></param>
        /// <param name="category_id_1"></param>
        /// <param name="category_id_2"></param>
        /// <param name="category_id_3"></param>
        /// <param name="category_id_4"></param>
        /// <param name="category_id_5"></param>
        /// <returns></returns>
        List<ViewParFile> GetQueryView_5(int tracking_id, int category_id_1, int category_id_2, int category_id_3, int category_id_4, int category_id_5);

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
