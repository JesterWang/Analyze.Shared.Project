namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.par_file_category")]
    public partial class par_file_category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte category_id { get; set; }

        [Required]
        [StringLength(20)]
        public string category { get; set; }

        [Required]
        [StringLength(20)]
        public string category_chil { get; set; }
    }
}
