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
        public string tracking_time { get; set; }
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
        /// 是否停线
        /// </summary>
        [Column(TypeName = "char")]
        [StringLength(1)]
        [Display(Name = "是否停线")]
        public string isline { get; set; }


        /// <summary>
        /// 设计方
        /// </summary>
        [Required(ErrorMessage = "请输入设计方")]
        [Display(Name = "设计方")]
        public string rd { get; set; }
        /// <summary>
        /// 问题类别
        /// </summary>
        [Required(ErrorMessage = "请输入问题类别")]
        [Display(Name = "问题类别")]
        public string issue_category { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        [Required(ErrorMessage = "请输入产品类型")]
        [Display(Name = "产品类型")]
        public string product_category { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "请输入状态")]
        [Display(Name = "状态")]
        public string status { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        [Display(Name = "问题描述")]
        public string problem_description { get; set; }
        /// <summary>
        /// 分析结论
        /// </summary>
        [Display(Name = "分析结论")]
        public string root_cause { get; set; }
        /// <summary>
        /// 改善措施
        /// </summary>
        [Display(Name = "改善措施")]
        public string analysis_conclusion { get; set; }
        /// <summary>
        /// 下一步计划
        /// </summary>
        [Display(Name = "下一步计划")]
        public string next_steps { get; set; }
        /// <summary>
        /// 问题总结图片
        /// </summary>
        [Display(Name = "问题总结图片")]
        [StringLength(200)]
        public string group_image { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public string create_owner { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public string update_time { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        [Display(Name = "操作日志")]
        public string log_result { get; set; }

    }
}
