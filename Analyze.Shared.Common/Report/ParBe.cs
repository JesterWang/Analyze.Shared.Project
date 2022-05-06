using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParBe
    {
        /// <summary>
        /// Id
        /// </summary>
        public int tracking_id { get; set; }
        /// <summary>
        /// 人员
        /// </summary>
        public string man { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public string machine { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// 环境
        /// </summary>
        public string environments { get; set; }
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
