using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyze.Shared.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Analyze.Shared.Common.Report
{

    public class ParList
    {
        public IEnumerable<ParFae> ParFae { get; set; }
        public IEnumerable<ParMe> ParMe { get; set; }
        public IEnumerable<ParEe> ParEe { get; set; }

        public IEnumerable<ParFileUpload> ParFileUpload { get; set; }
       
    }
}
