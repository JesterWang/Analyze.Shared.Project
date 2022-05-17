namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_menu_permission")]
    public partial class sys_menu_permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string menu_code { get; set; }

        public long? parent_id { get; set; }

        public sbyte node_type { get; set; }

        [StringLength(255)]
        public string icon_url { get; set; }

        public int sort { get; set; }

        [StringLength(500)]
        public string link_url { get; set; }

        public int level { get; set; }

        [StringLength(2500)]
        public string path { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string is_delete { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime update_date { get; set; }
    }
}
