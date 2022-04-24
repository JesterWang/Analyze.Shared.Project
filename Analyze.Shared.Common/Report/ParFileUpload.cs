using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ParFileUpload
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 主键Id
        /// </summary>
        public int tracking_id { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_url { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string file_name { get; set; }
        /// <summary>
        /// 文件上传日期
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 文件更新日期
        /// </summary>
        public DateTime update_time { get; set; }
        /// <summary>
        /// 文件上传用户名+姓名
        /// </summary>
        public string user_detailed { get; set; }

        /// <summary>
        /// 附件分类
        ///【"1""FAE""问题分析报告"】
        ///【"2""ME""问题分析报告"】
        ///【"3""EE""问题分析报告"】
        ///【"4""物料""物料1排查步骤"】
        ///【"5""物料""物料2排查步骤"】
        ///【"6""物料""物料3排查步骤"】
        ///【"7""物料""物料4排查步骤"】
        ///【"8""SMT""人员排查"】
        ///【"9""SMT""设备排查"】
        ///【"10""SMT""方法排查"】
        ///【"11""SMT""环境排查"】
        ///【"12""组装""人员排查"】
        ///【"13""组装""设备排查"】
        ///【"14""组装""方法排查"】
        ///【"15""组装""环境排查"】
        ///【"16""测试""FE"】
        ///【"18""测试""CFC"】
        ///【"18""测试""CFC"】
        ///【"19""测试""SD BU"】
        /// </summary>
        public byte category_id { get; set; }
    }
}
