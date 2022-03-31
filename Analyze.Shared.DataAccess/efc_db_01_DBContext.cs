namespace Analyze.Shared.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public partial class efc_db_01_DBContext : DbContext
    {
        public efc_db_01_DBContext()
            : base("name=efc_db_01_Config")
        {
        }

        public virtual DbSet<sys_dept> sys_dept { get; set; }
        public virtual DbSet<sys_emp> sys_emp { get; set; }
        public virtual DbSet<sys_job> sys_job { get; set; }
        public virtual DbSet<sys_role> sys_role { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sys_dept>()
                .Property(e => e.dname_short)
                .IsUnicode(false);

            modelBuilder.Entity<sys_dept>()
                .Property(e => e.dname_short_splicing)
                .IsUnicode(false);

            modelBuilder.Entity<sys_emp>()
                .Property(e => e.wid)
                .IsUnicode(false);

            modelBuilder.Entity<sys_emp>()
                .Property(e => e.ename)
                .IsUnicode(false);

            modelBuilder.Entity<sys_emp>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<sys_emp>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<sys_emp>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sys_job>()
                .Property(e => e.job)
                .IsUnicode(false);

            modelBuilder.Entity<sys_role>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
