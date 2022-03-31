using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class CurrentUser
    {
        public int Id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int emp_id { get; set; }

        public int role_id { get; set; }

        public int status { get; set; }

        public DateTime create_time { get; set; }
    }
}
