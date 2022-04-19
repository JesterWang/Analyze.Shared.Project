namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.par_materials")]
    public partial class par_materials
    {
        [Key]
        [Column(TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tracking_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string materials_steps_1 { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string materials_steps_2 { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string materials_steps_3 { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string materials_steps_4 { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string log_result { get; set; }
    }
}
