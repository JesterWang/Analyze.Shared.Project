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
    public class ParSmtService : BaseService, IParSmtService
    {
        public ParSmtService(DbContext context)
            : base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public ParSmt GetQueryReport(int tracking_id) 
        {
            ParSmt par = Context.Set<par_smt>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParSmt
                {
                    tracking_id = e.tracking_id,
                    man = e.man,
                    machine = e.machine,
                    method = e.method,
                    environments = e.environments,
                    materials = e.materials,
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
        }

        /// <summary>
        /// 修改Smt问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUpdateReport(ParSmt parSmt) 
        {
            par_smt parContext = new par_smt()
            {
                tracking_id = parSmt.tracking_id,
                man = parSmt.man,
                machine = parSmt.machine,
                method = parSmt.method,
                environments = parSmt.environments,
                materials = parSmt.materials,
                log_result = parSmt.log_result
            };
            Context.Set<par_smt>().Attach(parContext);
            Context.Entry<par_smt>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
