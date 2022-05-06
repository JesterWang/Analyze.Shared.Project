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
    public class ParTestService : BaseService, IParTestService
    {
        public ParTestService(DbContext context)
            : base(context) 
        {

        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="_tracking_id"></param>
        /// <returns></returns>
        public ParTest GetQueryReport(int tracking_id) 
        {
            ParTest par = Context.Set<par_test>().Where(e => e.tracking_id == tracking_id)
                .Select(e => new ParTest
                {
                    tracking_id = e.tracking_id,
                    fe = e.fe,
                    be = e.be,
                    cfc = e.cfc,
                    sdbu = e.sdbu,
                    update_time = e.update_time,
                    log_result = e.log_result
                }).FirstOrDefault();
            return par;
        }

        /// <summary>
        /// 修改Test问题分析报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUpdateReport(ParTest parTest) 
        {
            par_test parContext = new par_test()
            {
                tracking_id = parTest.tracking_id,
                fe = parTest.fe,
                be = parTest.be,
                cfc = parTest.cfc,
                sdbu = parTest.sdbu,
                log_result = parTest.log_result
            };
            Context.Set<par_test>().Attach(parContext);
            Context.Entry<par_test>(parContext).State = EntityState.Modified;
            Context.SaveChanges();
            return true;
        }
    }
}
