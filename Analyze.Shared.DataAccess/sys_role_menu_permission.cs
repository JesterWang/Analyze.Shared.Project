namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_role_menu_permission")]
    public partial class sys_role_menu_permission
    {
        [Column(TypeName = "usmallint")]
        public int role_id { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal menu_permission_id { get; set; }

        [Required]
        [StringLength(100)]
        public string note { get; set; }

        [Column(TypeName = "umediumint")]
        public int id { get; set; }
    }
}
