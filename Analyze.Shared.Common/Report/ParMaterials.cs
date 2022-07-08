using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParMaterials
    {

        public int id { get; set; }

        /// <summary>
        /// tracking_id
        /// </summary>
        public int tracking_id { get; set; }
        /// <summary>
        /// 异常位号
        /// </summary>
        [Required(ErrorMessage = "请输入异常位号")]
        [Display(Name = "异常位号")]
        public string tag_number { get; set; }
        /// <summary>
        /// Lenovo P/N
        /// </summary>
        [Required(ErrorMessage = "请输入Lenovo P/N")]
        [Display(Name = "Lenovo P/N")]
        public string lenovo_pn { get; set; }
        /// <summary>
        /// ODM P/N
        /// </summary>
        [Required(ErrorMessage = "请输入ODM P/N")]
        [Display(Name = "ODM P/N")]
        public string odm_pn { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [Required(ErrorMessage = "请输入供应商")]
        [Display(Name = "供应商")]
        public string supplier { get; set; }
        /// <summary>
        /// 嫌疑批次
        /// </summary>
        [Required(ErrorMessage = "请输入嫌疑批次")]
        [Display(Name = "嫌疑批次")]
        public string suspect_batch { get; set; }
        /// <summary>
        /// 嫌疑Lot号
        /// </summary>
        [Required(ErrorMessage = "请输入嫌疑Lot号")]
        [Display(Name = "嫌疑Lot号")]
        public string suspect_lot { get; set; }
        /// <summary>
        /// 其他批次
        /// </summary>
        [Required(ErrorMessage = "请输入其他批次")]
        [Display(Name = "其他批次")]
        public string other_batch { get; set; }
        /// <summary>
        /// 其他批次数量
        /// </summary>
        [Required(ErrorMessage = "请输入其他批次数量")]
        [Display(Name = "其他批次数量")]
        public string other_batch_number { get; set; }
        /// <summary>
        /// 替代料
        /// </summary>
        [Required(ErrorMessage = "请输入替代料")]
        [Display(Name = "替代料")]
        public string alternative_materials { get; set; }
        /// <summary>
        /// 使用产品
        /// </summary>
        [Required(ErrorMessage = "请输入使用产品")]
        [Display(Name = "使用产品")]
        public string product { get; set; }
        /// <summary>
        /// 近期2月/试产有无相同问题
        /// </summary>
        [Required(ErrorMessage = "请输入")]
        [Display(Name = "近期2月/试产有无相同问题")]
        public string is_npi_issue { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string remark { get; set; }
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
