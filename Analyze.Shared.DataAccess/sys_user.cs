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
        [Required]
        [StringLength(32)]
        public string username { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string emplyee_name { get; set; }

        [Required]
        [StringLength(20)]
        public string emplyee_itcode { get; set; }

        [Required]
        [StringLength(50)]
        public string sex { get; set; }

        [Required]
        [StringLength(20)]
        public string tel { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        public byte role_id { get; set; }

        public byte job_id { get; set; }

        [Column(TypeName = "usmallint")]
        public int dept_id { get; set; }

        public byte status { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}
