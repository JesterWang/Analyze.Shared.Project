using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Bussiness.Interface
{
    //分页
    public class PageResult<T> : AjaxResult
    {
        public int Total { get; set; }

        public List<T> Rows { get; set; }

        public PageResult()
        {
            Rows = new List<T>();
        }
    }
}
