namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_user")]
    public partial class sys_user
    {
        public short id { get; set; }

        [Required]
        [StringLength(8)]
        public string username { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        public short emp_id { get; set; }

        public short role_id { get; set; }

        public sbyte status { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }
    }
}
