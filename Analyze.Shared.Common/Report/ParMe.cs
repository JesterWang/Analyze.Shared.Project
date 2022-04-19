using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParMe
    {
        public int tracking_id { get; set; }

        [StringLength(65535)]
        [Required(ErrorMessage = "请输入分析结论")]
        public string analysis_conclusion { get; set; }

        [StringLength(65535)]
        [Required(ErrorMessage = "请输入分析步骤")]
        public string analysis_steps { get; set; }

        public DateTime update_time { get; set; }

        [StringLength(65535)]
        public string log_result { get; set; }
    }
}
