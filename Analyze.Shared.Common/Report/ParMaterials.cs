using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParMaterials
    {
        /// <summary>
        /// Id
        /// </summary>
        public int tracking_id { get; set; }
        /// <summary>
        /// 物料1
        /// </summary>
        public string materials_steps_1 { get; set; }
        /// <summary>
        /// 物料2
        /// </summary>
        public string materials_steps_2 { get; set; }
        /// <summary>
        /// 物料3
        /// </summary>
        public string materials_steps_3 { get; set; }
        /// <summary>
        /// 物料4
        /// </summary>
        public string materials_steps_4 { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime update_time { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        public string log_result { get; set; }
    }
}
