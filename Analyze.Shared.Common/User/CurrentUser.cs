using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class CurrentUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public string emplyee_name { get; set; }
        public string emplyee_itcode { get; set; }
        public string sex { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public byte role_id { get; set; }
        public byte job_id { get; set; }
        public int dept_id { get; set; }
        public byte status { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public int id { get; set; }
    }
}
