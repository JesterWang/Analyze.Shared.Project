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
    public class ParMeService : BaseService,IParMeService
    {
        public ParMeService(DbContext context): base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public ParMe GetQueryReport(int tracking_id)
        {
            ParMe par = Context.Set<par_me>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParMe
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
        public bool GetUpdateReport(ParMe parMe) 
        {
            par_me parContext = new par_me()
            {
                tracking_id = parMe.tracking_id,
                analysis_conclusion = parMe.analysis_conclusion,
                analysis_steps = parMe.analysis_steps,
                log_result = parMe.log_result
            };
            Context.Set<par_me>().Attach(parContext);
            Context.Entry<par_me>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
