namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.par_fae")]
    public partial class par_fae
    {
        [Key]
        [Column(TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tracking_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string analysis_conclusion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string analysis_steps { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string log_result { get; set; }
    }
}
