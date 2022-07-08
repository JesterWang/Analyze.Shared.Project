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
    public class ParMaterialsService : BaseService, IParMaterialsService
    {
        public ParMaterialsService(DbContext context)
            : base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public List<ParMaterials> GetQueryReport(int tracking_id) 
        {
            List<ParMaterials> listParMaterials = new List<ParMaterials>();
            listParMaterials = Context.Set<par_materials>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParMaterials
                {
                    tracking_id = e.tracking_id,
                    tag_number = e.tag_number,
                    lenovo_pn = e.lenovo_pn,
                    odm_pn = e.odm_pn,
                    supplier = e.supplier,
                    suspect_batch = e.suspect_batch,
                    suspect_lot = e.suspect_lot,
                    other_batch = e.other_batch,
                    other_batch_number = e.other_batch_number,
                    alternative_materials = e.alternative_materials,
                    product = e.product,
                    is_npi_issue = e.is_npi_issue,
                    remark = e.remark,
                    update_time = e.update_time,
                    log_result = e.log_result,
                    id = e.id
                }).OrderByDescending(e => e.update_time).ToList();
            return listParMaterials;
        }

        /// <summary>
        /// 修改Materials问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUpdateReport(ParMaterials parMaterials) 
        {
            par_materials parContext = new par_materials()
            {
                tracking_id = parMaterials.tracking_id,
                tag_number = parMaterials.tag_number,
                lenovo_pn = parMaterials.lenovo_pn,
                odm_pn = parMaterials.odm_pn,
                supplier = parMaterials.supplier,
                suspect_batch = parMaterials.suspect_batch,
                suspect_lot = parMaterials.suspect_lot,
                other_batch = parMaterials.other_batch,
                other_batch_number = parMaterials.other_batch_number,
                alternative_materials = parMaterials.alternative_materials,
                product = parMaterials.product,
                is_npi_issue = parMaterials.is_npi_issue,
                remark = parMaterials.remark,
                update_time = parMaterials.update_time,
                log_result = parMaterials.log_result,
                id = parMaterials.id
            };
            Context.Set<par_materials>().Attach(parContext);
            Context.Entry<par_materials>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 添加Materials问题分析报告
        /// </summary>
        /// <param name="parMaterials"></param>
        /// <returns></returns>
        public bool Insert(ParMaterials parMaterials)
        {
            par_materials parContext = new par_materials()
            {
                tracking_id = parMaterials.tracking_id,
                tag_number = parMaterials.tag_number,
                lenovo_pn = parMaterials.lenovo_pn,
                odm_pn = parMaterials.odm_pn,
                supplier = parMaterials.supplier,
                suspect_batch = parMaterials.suspect_batch,
                suspect_lot = parMaterials.suspect_lot,
                other_batch = parMaterials.other_batch,
                other_batch_number = parMaterials.other_batch_number,
                alternative_materials = parMaterials.alternative_materials,
                product = parMaterials.product,
                is_npi_issue = parMaterials.is_npi_issue,
                remark = parMaterials.remark,
                log_result = parMaterials.log_result
            };
            Context.Set<par_materials>().Add(parContext);
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 修改Materials问题分析报告
        /// </summary>
        /// <param name="parMaterials"></param>
        /// <returns></returns>
        public bool Update(ParMaterials parMaterials)
        {
            par_materials parContext = new par_materials()
            {
                id= parMaterials.id,
                tracking_id = parMaterials.tracking_id,
                tag_number = parMaterials.tag_number,
                lenovo_pn = parMaterials.lenovo_pn,
                odm_pn = parMaterials.odm_pn,
                supplier = parMaterials.supplier,
                suspect_batch = parMaterials.suspect_batch,
                suspect_lot = parMaterials.suspect_lot,
                other_batch = parMaterials.other_batch,
                other_batch_number = parMaterials.other_batch_number,
                alternative_materials = parMaterials.alternative_materials,
                product = parMaterials.product,
                is_npi_issue = parMaterials.is_npi_issue,
                remark = parMaterials.remark,
                update_time=DateTime.Now,
                log_result = parMaterials.log_result
            };
            Context.Set<par_materials>().Attach(parContext);
            Context.Entry<par_materials>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除Materials信息-单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            par_materials parContext = Find<par_materials>(id);
            Context.Set<par_materials>().Remove(parContext);
            Context.SaveChanges();
            return true;
        }
    }
}
