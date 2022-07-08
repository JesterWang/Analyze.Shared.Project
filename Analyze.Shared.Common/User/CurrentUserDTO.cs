using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class CurrentUserDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        [StringLength(32, ErrorMessage = "用户名不能超过32个字符")]
        [Display(Name = "用户名")]
        public string username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(200, ErrorMessage = "密码不能超过200个字符")]
        [Display(Name = "密码")]
        public string password { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        [StringLength(20, ErrorMessage = "姓名不能超过20个字符")]
        [Display(Name = "姓名")]
        public string employee_name { get; set; }

        /// <summary>
        /// ITCode
        /// </summary>
        [Display(Name = "ITCode")]
        public string employee_itcode { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public string sex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Display(Name = "电话")]
        public string tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        public string email { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        [Display(Name = "职位")]
        public byte job_id { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        [Display(Name = "组织")]
        public decimal dept_id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public string status { get; set; }
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
        public int id { get; set; }
    }
}
