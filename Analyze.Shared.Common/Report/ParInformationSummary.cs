using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParInformationSummary
    {
        /// <summary>
        /// 单号Id
        /// </summary>
        public int tracking_id { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string tracking_number { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime? tracking_time { get; set; }
        /// <summary>
        /// 发生地点
        /// </summary>
        public string site { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// 不良率
        /// </summary>
        public string defect_rate { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string problem_description { get; set; }
        /// <summary>
        /// 不良原因
        /// </summary>
        public string root_cause { get; set; }
        /// <summary>
        /// 不良图片 URL
        /// </summary>
        public string defect_img_url { get; set; }
        /// <summary>
        /// 分析结论汇总图片 URL
        /// </summary>
        public string conclusion_img_url { get; set; }
        /// <summary>
        /// 分析结论
        /// </summary>
        public string analysis_conclusion { get; set; }
        /// <summary>
        /// 下一步计划
        /// </summary>
        public string next_steps { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
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
