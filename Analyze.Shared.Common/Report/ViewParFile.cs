using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.Report
{
    public class ViewParFile
    {
        public int tracking_id { get; set; }
        public string file_url { get; set; }
        public string file_name { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public string user_detailed { get; set; }
        public string category { get; set; }
        public string category_chil { get; set; }
        public byte? category_id { get; set; }
    }
}
