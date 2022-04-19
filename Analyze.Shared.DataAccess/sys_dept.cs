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
        [Column(TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column(TypeName = "usmallint")]
        public int parent_id_1 { get; set; }

        [Column(TypeName = "usmallint")]
        public int parent_id_2 { get; set; }

        [Required]
        [StringLength(20)]
        public string dname_short { get; set; }

        [Required]
        [StringLength(32)]
        public string dname_short_splicing { get; set; }
    }
}
