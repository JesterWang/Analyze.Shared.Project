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
    public class ParFaeService : BaseService, IParFaeService
    {
        public ParFaeService(DbContext context)
            : base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public ParFae GetQueryReport(int tracking_id)
        {
            ParFae par = Context.Set<par_fae>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParFae
                {
                    tracking_id = e.tracking_id,
                    analysis_conclusion = e.analysis_conclusion,
                    analysis_steps = e.analysis_steps,
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
        }

        /// <summary>
        /// 修改ME问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUpdateReport(ParFae parFae) 
        {
            par_fae parContext = new par_fae()
            {
                tracking_id = parFae.tracking_id,
                analysis_conclusion = parFae.analysis_conclusion,
                analysis_steps = parFae.analysis_steps,
                log_result = parFae.log_result
            };
            Context.Set<par_fae>().Attach(parContext);
            Context.Entry<par_fae>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
