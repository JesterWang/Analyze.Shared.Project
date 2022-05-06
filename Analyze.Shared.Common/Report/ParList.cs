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
        public IEnumerable<ParInformationSummary> ParInformationSummary { get; set; }
        public IEnumerable<ParFae> ParFae { get; set; }
        public IEnumerable<ParMe> ParMe { get; set; }
        public IEnumerable<ParEe> ParEe { get; set; }
        public IEnumerable<ParMaterials> ParMaterials { get; set; }
        public IEnumerable<ParSmt> ParSmt { get; set; }
        public IEnumerable<ParBe> ParBe { get; set; }
        public IEnumerable<ParTest> ParTest { get; set; }

        public IEnumerable<ParFileUpload> ParFileUpload { get; set; }
        public IEnumerable<ViewParFile> ViewParFile { get; set; }
    }
}
