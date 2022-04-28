using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "单号")]
        public string tracking_number { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage="请输入标题")]
        [StringLength(50, ErrorMessage = "标题不能超过50个字符")]
        [Display(Name = "标题")]
        public string title { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        [Display(Name = "发生时间")]
        public DateTime? tracking_time { get; set; }
        /// <summary>
        /// 发生地点
        /// </summary>
        [Required(ErrorMessage = "请输入发生地点")]
        [StringLength(50, ErrorMessage = "发生地点不能超过50个字符")]
        [Display(Name = "发生地点")]
        public string site { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        [Required(ErrorMessage = "请输入产品型号")]
        [StringLength(32, ErrorMessage = "产品型号不能超过32个字符")]
        [Display(Name = "产品型号")]
        public string model { get; set; }
        /// <summary>
        /// 不良率
        /// </summary>
        [Required(ErrorMessage = "请输入不良率")]
        [Display(Name = "不良率")]
        public string defect_rate { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        [Display(Name = "问题描述")]
        public string problem_description { get; set; }
        /// <summary>
        /// 不良原因
        /// </summary>
        [Display(Name = "不良原因")]
        public string root_cause { get; set; }
        /// <summary>
        /// 分析结论
        /// </summary>
        [Display(Name = "分析结论")]
        public string analysis_conclusion { get; set; }
        /// <summary>
        /// 下一步计划
        /// </summary>
        [Display(Name = "下一步计划")]
        public string next_steps { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public DateTime update_time { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        [Display(Name = "操作日志")]
        public string log_result { get; set; }

    }
}
