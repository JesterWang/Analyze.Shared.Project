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
        [Column(TypeName = "umediumint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(32)]
        public string username { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [StringLength(20)]
        public string employee_name { get; set; }

        [StringLength(20)]
        public string employee_itcode { get; set; }

        [StringLength(50)]
        public string sex { get; set; }

        [StringLength(20)]
        public string tel { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        public byte job_id { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal dept_id { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string status { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }
    }
}
