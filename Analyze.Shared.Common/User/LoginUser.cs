using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class LoginUser
    {
        [Required(ErrorMessage="请输入用户名")]
        [StringLength(8,ErrorMessage="用户名不能超过8个字符")]
        public string username { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        public string password { get; set; }
    }
}
