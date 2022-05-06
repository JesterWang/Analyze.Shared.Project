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
        public ParMaterials GetQueryReport(int tracking_id) 
        {
            ParMaterials par = Context.Set<par_materials>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParMaterials
                {
                    tracking_id = e.tracking_id,
                    materials_steps_1 = e.materials_steps_1,
                    materials_steps_2 = e.materials_steps_2,
                    materials_steps_3 = e.materials_steps_3,
                    materials_steps_4 = e.materials_steps_4,
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
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
                materials_steps_1 = parMaterials.materials_steps_1,
                materials_steps_2 = parMaterials.materials_steps_2,
                materials_steps_3 = parMaterials.materials_steps_3,
                materials_steps_4 = parMaterials.materials_steps_4,
                log_result = parMaterials.log_result
            };
            Context.Set<par_materials>().Attach(parContext);
            Context.Entry<par_materials>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
