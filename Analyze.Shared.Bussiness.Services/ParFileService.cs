using Analyze.Shared.Bussiness.Interface;
using Analyze.Shared.Common.Report;
using Analyze.Shared.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Services
{
    public class ParFileService : BaseService, IParFileService
    {
        public ParFileService(DbContext context): base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public List<ParFileUpload> GetQuery(int tracking_id, int category_id)
        {
            List<ParFileUpload> listParFileUpload = new List<ParFileUpload>();
            listParFileUpload = Context.Set<par_file_upload>().Where(e => e.tracking_id == tracking_id && e.category_id == category_id)
                .Select(e => new ParFileUpload
                {
                    id=e.id,
                    tracking_id = e.tracking_id,
                    file_url=e.file_url,
                    file_name = e.file_name,
                    create_time=e.create_time,
                    update_time=e.update_time,
                    user_detailed = e.user_detailed,
                    category_id = e.category_id
                }).OrderByDescending(e => e.create_time).ToList();
            return listParFileUpload;
        }

        /// <summary>
        /// 添加文件信息-单条
        /// </summary>
        /// <param name="parFileUpload"></param>
        /// <returns></returns>
        public bool GetInsert(ParFileUpload parFileUpload)
        {
            par_file_upload parContext = new par_file_upload()
            {
                tracking_id = parFileUpload.tracking_id,
                file_url = parFileUpload.file_url,
                file_name = parFileUpload.file_name,
                user_detailed = parFileUpload.user_detailed,
                category_id = parFileUpload.category_id
            };
            Context.Set<par_file_upload>().Add(parContext);
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除文件信息-单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetDelete(int id) 
        {
            par_file_upload parContext = Find<par_file_upload>(id);
            Context.Set<par_file_upload>().Remove(parContext);
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 查询视图报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public List<ViewParFile> GetQueryView(int tracking_id, int category_id_1,int category_id_2,int category_id_3,int category_id_4)
        {
            List<ViewParFile> listViewParFile = new List<ViewParFile>();
            listViewParFile = Context.Set<view_par_file>().Where(e => e.tracking_id == tracking_id && (e.category_id == category_id_1 || e.category_id == category_id_2 || e.category_id == category_id_3 || e.category_id == category_id_4))
                .Select(e => new ViewParFile
                {
                    id = e.id,
                    tracking_id = e.tracking_id,
                    file_url = e.file_url,
                    file_name = e.file_name,
                    create_time = e.create_time,
                    update_time = e.update_time,
                    user_detailed = e.user_detailed,
                    category=e.category,
                    category_chil=e.category_chil,
                    category_id = e.category_id
                }).OrderByDescending(e => e.create_time).ToList();
            return listViewParFile;
        }

        /// <summary>
        /// 查询视图报表-1个分类
        /// </summary>
        /// <param name="tracking_id"></param>
        /// <param name="category_id_1"></param>
        /// <returns></returns>
        public List<ViewParFile> GetQueryView_1(int tracking_id, int category_id_1)
        {
            List<ViewParFile> listViewParFile = new List<ViewParFile>();
            listViewParFile = Context.Set<view_par_file>().Where(e => e.tracking_id == tracking_id && (e.category_id == category_id_1))
                .Select(e => new ViewParFile
                {
                    id = e.id,
                    tracking_id = e.tracking_id,
                    file_url = e.file_url,
                    file_name = e.file_name,
                    create_time = e.create_time,
                    update_time = e.update_time,
                    user_detailed = e.user_detailed,
                    category = e.category,
                    category_chil = e.category_chil,
                    category_id = e.category_id
                }).OrderByDescending(e => e.create_time).ToList();
            return listViewParFile;
        }

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
        public List<ViewParFile> GetQueryView_5(int tracking_id, int category_id_1, int category_id_2, int category_id_3, int category_id_4, int category_id_5)
        {
            List<ViewParFile> listViewParFile = new List<ViewParFile>();
            listViewParFile = Context.Set<view_par_file>().Where(e => e.tracking_id == tracking_id && (e.category_id == category_id_1 || e.category_id == category_id_2 || e.category_id == category_id_3 || e.category_id == category_id_4 || e.category_id == category_id_5))
                .Select(e => new ViewParFile
                {
                    id = e.id,
                    tracking_id = e.tracking_id,
                    file_url = e.file_url,
                    file_name = e.file_name,
                    create_time = e.create_time,
                    update_time = e.update_time,
                    user_detailed = e.user_detailed,
                    category = e.category,
                    category_chil = e.category_chil,
                    category_id = e.category_id
                }).OrderByDescending(e => e.create_time).ToList();
            return listViewParFile;
        }

    }
}
