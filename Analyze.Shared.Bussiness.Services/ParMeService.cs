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
    }
}
