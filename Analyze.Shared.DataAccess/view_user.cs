namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.view_user")]
    public partial class view_user
    {
        [Key]
        [Column(Order = 0, TypeName = "umediumint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(32)]
        public string username { get; set; }

        [Key]
        [Column(Order = 2)]
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

        [Key]
        [Column(Order = 3)]
        public byte job_id { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "ubigint")]
        public decimal dept_id { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "char")]
        [StringLength(1)]
        public string status { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "timestamp")]
        public DateTime create_time { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "timestamp")]
        public DateTime update_time { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string job { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(20)]
        public string dname_short { get; set; }
    }
}
