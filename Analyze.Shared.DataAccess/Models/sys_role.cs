namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_role")]
    public partial class sys_role
    {
        public short id { get; set; }

        [Required]
        [StringLength(20)]
        public string role { get; set; }
    }
}
