namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.view_par_file")]
    public partial class view_par_file
    {
        [Key]
        [Column(Order = 0, TypeName = "usmallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tracking_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string file_url { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string file_name { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "timestamp")]
        public DateTime create_time { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "timestamp")]
        public DateTime update_time { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string user_detailed { get; set; }

        [StringLength(20)]
        public string category { get; set; }

        [StringLength(20)]
        public string category_chil { get; set; }

        public byte? category_id { get; set; }
    }
}
