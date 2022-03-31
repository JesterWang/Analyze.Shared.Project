namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_job")]
    public partial class sys_job
    {
        public short id { get; set; }

        [StringLength(20)]
        public string job { get; set; }
    }
}
