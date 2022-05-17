using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common.User
{
    public class MenuPermission
    {
        public MenuPermission() 
        {
            Submenu = new List<MenuPermission>();
        }
        public long id { get; set; }

        public string name { get; set; }

        public string menu_code { get; set; }

        public long? parent_id { get; set; }

        public sbyte node_type { get; set; }

        public string icon_url { get; set; }

        public int sort { get; set; }

        public string link_url { get; set; }

        public int level { get; set; }

        public string path { get; set; }

        public sbyte is_delete { get; set; }

        public DateTime update_date { get; set; }

        public List<MenuPermission> Submenu { get; set; }
    }
}
