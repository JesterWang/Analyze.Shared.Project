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
        public int tracking_id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string tag_number { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string lenovo_pn { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string odm_pn { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string supplier { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string suspect_batch { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string suspect_lot { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string other_batch { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string other_batch_number { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string alternative_materials { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string product { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string is_npi_issue { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string log_result { get; set; }

        [Column(TypeName = "umediumint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}
