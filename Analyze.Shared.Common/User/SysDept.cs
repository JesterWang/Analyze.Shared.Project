using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class SysDept
    {
        public decimal id { get; set; }

        public decimal parent_id { get; set; }

        public byte sort { get; set; }

        public byte level { get; set; }

        public string path { get; set; }

        public string dname_short { get; set; }

        public string dname_short_splicing { get; set; }

        public string manager { get; set; }

        public DateTime update_time { get; set; }
    }
}
