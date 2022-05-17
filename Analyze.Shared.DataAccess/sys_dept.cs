namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_dept")]
    public partial class sys_dept
    {
        [Column(TypeName = "ubigint")]
        public decimal id { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal parent_id { get; set; }

        public byte sort { get; set; }

        public byte level { get; set; }

        [Required]
        [StringLength(100)]
        public string path { get; set; }

        [Required]
        [StringLength(20)]
        public string dname_short { get; set; }

        [Required]
        [StringLength(32)]
        public string dname_short_splicing { get; set; }

        [Required]
        [StringLength(20)]
        public string manager { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }
    }
}
