namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.par_information_summary")]
    public partial class par_information_summary
    {
        [Key]
        [Column(TypeName = "usmallint")]
        public int tracking_id { get; set; }

        [Required]
        [StringLength(20)]
        public string tracking_number { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? tracking_time { get; set; }

        [Required]
        [StringLength(50)]
        public string site { get; set; }

        [Required]
        [StringLength(32)]
        public string model { get; set; }

        [Required]
        [StringLength(32)]
        public string defect_rate { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string problem_description { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string root_cause { get; set; }

        [Required]
        [StringLength(200)]
        public string defect_img_url { get; set; }

        [Required]
        [StringLength(200)]
        public string conclusion_img_url { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string analysis_conclusion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string next_steps { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? create_time { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_time { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string log_result { get; set; }
    }
}
