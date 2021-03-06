namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.par_be")]
    public partial class par_be
    {
        [Key]
        [Column(TypeName = "umediumint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tracking_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string man { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string machine { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string method { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string environments { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string log_result { get; set; }
    }
}
