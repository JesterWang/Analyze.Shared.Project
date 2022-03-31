namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_emp")]
    public partial class sys_emp
    {
        public short id { get; set; }

        [Required]
        [StringLength(20)]
        public string wid { get; set; }

        [Required]
        [StringLength(20)]
        public string ename { get; set; }

        [Required]
        [StringLength(50)]
        public string sex { get; set; }

        [Required]
        [StringLength(20)]
        public string tel { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        public sbyte job_id { get; set; }

        public sbyte dept_id { get; set; }

        public sbyte mgr_id { get; set; }

        public sbyte status { get; set; }
    }
}
