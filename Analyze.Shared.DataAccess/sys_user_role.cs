namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("efc_db_01.sys_user_role")]
    public partial class sys_user_role
    {
        [Column(TypeName = "umediumint")]
        public int user_id { get; set; }

        [Column(TypeName = "usmallint")]
        public int role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_role_note { get; set; }

        [Column(TypeName = "umediumint")]
        public int id { get; set; }
    }
}
