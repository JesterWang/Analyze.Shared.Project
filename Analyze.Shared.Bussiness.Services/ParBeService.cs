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
    public class ParBeService : BaseService, IParBeService
    {
        public ParBeService(DbContext context)
            : base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public ParBe GetQueryReport(int tracking_id)
        {
            ParBe par = Context.Set<par_be>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParBe
                {
                    tracking_id = e.tracking_id,
                    man = e.man,
                    machine = e.machine,
                    method = e.method,
                    environments = e.environments,
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
        }

        /// <summary>
        /// 修改Be问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUpdateReport(ParBe parBe)
        {
            par_be parContext = new par_be()
            {
                tracking_id = parBe.tracking_id,
                man = parBe.man,
                machine = parBe.machine,
                method = parBe.method,
                environments = parBe.environments,
                log_result = parBe.log_result
            };
            Context.Set<par_be>().Attach(parContext);
            Context.Entry<par_be>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
