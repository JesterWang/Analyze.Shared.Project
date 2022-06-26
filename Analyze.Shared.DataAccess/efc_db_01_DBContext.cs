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

        public virtual DbSet<par_be> par_be { get; set; }
        public virtual DbSet<par_ee> par_ee { get; set; }
        public virtual DbSet<par_fae> par_fae { get; set; }
        public virtual DbSet<par_file_category> par_file_category { get; set; }
        public virtual DbSet<par_file_upload> par_file_upload { get; set; }
        public virtual DbSet<par_information_summary> par_information_summary { get; set; }
        public virtual DbSet<par_materials> par_materials { get; set; }
        public virtual DbSet<par_me> par_me { get; set; }
        public virtual DbSet<par_smt> par_smt { get; set; }
        public virtual DbSet<par_test> par_test { get; set; }
        public virtual DbSet<sys_dept> sys_dept { get; set; }
        public virtual DbSet<sys_job> sys_job { get; set; }
        public virtual DbSet<sys_menu_permission> sys_menu_permission { get; set; }
        public virtual DbSet<sys_role> sys_role { get; set; }
        public virtual DbSet<sys_role_menu_permission> sys_role_menu_permission { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }
        public virtual DbSet<sys_user_role> sys_user_role { get; set; }
        public virtual DbSet<view_par_file> view_par_file { get; set; }
        public virtual DbSet<view_user> view_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<par_be>()
                .Property(e => e.man)
                .IsUnicode(false);

            modelBuilder.Entity<par_be>()
                .Property(e => e.machine)
                .IsUnicode(false);

            modelBuilder.Entity<par_be>()
                .Property(e => e.method)
                .IsUnicode(false);

            modelBuilder.Entity<par_be>()
                .Property(e => e.environments)
                .IsUnicode(false);

            modelBuilder.Entity<par_be>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_ee>()
                .Property(e => e.analysis_conclusion)
                .IsUnicode(false);

            modelBuilder.Entity<par_ee>()
                .Property(e => e.analysis_steps)
                .IsUnicode(false);

            modelBuilder.Entity<par_ee>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_fae>()
                .Property(e => e.analysis_conclusion)
                .IsUnicode(false);

            modelBuilder.Entity<par_fae>()
                .Property(e => e.analysis_steps)
                .IsUnicode(false);

            modelBuilder.Entity<par_fae>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_file_category>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<par_file_category>()
                .Property(e => e.category_chil)
                .IsUnicode(false);

            modelBuilder.Entity<par_file_upload>()
                .Property(e => e.file_url)
                .IsUnicode(false);

            modelBuilder.Entity<par_file_upload>()
                .Property(e => e.file_name)
                .IsUnicode(false);

            modelBuilder.Entity<par_file_upload>()
                .Property(e => e.user_detailed)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.tracking_number)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.site)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.defect_rate)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.isline)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.rd)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.issue_category)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.product_category)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.problem_description)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.root_cause)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.analysis_conclusion)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.next_steps)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.group_image)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.create_owner)
                .IsUnicode(false);

            modelBuilder.Entity<par_information_summary>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_materials>()
                .Property(e => e.materials_steps_1)
                .IsUnicode(false);

            modelBuilder.Entity<par_materials>()
                .Property(e => e.materials_steps_2)
                .IsUnicode(false);

            modelBuilder.Entity<par_materials>()
                .Property(e => e.materials_steps_3)
                .IsUnicode(false);

            modelBuilder.Entity<par_materials>()
                .Property(e => e.materials_steps_4)
                .IsUnicode(false);

            modelBuilder.Entity<par_materials>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_me>()
                .Property(e => e.analysis_conclusion)
                .IsUnicode(false);

            modelBuilder.Entity<par_me>()
                .Property(e => e.analysis_steps)
                .IsUnicode(false);

            modelBuilder.Entity<par_me>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_smt>()
                .Property(e => e.man)
                .IsUnicode(false);

            modelBuilder.Entity<par_smt>()
                .Property(e => e.machine)
                .IsUnicode(false);

            modelBuilder.Entity<par_smt>()
                .Property(e => e.method)
                .IsUnicode(false);

            modelBuilder.Entity<par_smt>()
                .Property(e => e.environments)
                .IsUnicode(false);

            modelBuilder.Entity<par_smt>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<par_test>()
                .Property(e => e.fe)
                .IsUnicode(false);

            modelBuilder.Entity<par_test>()
                .Property(e => e.be)
                .IsUnicode(false);

            modelBuilder.Entity<par_test>()
                .Property(e => e.cfc)
                .IsUnicode(false);

            modelBuilder.Entity<par_test>()
                .Property(e => e.sdbu)
                .IsUnicode(false);

            modelBuilder.Entity<par_test>()
                .Property(e => e.log_result)
                .IsUnicode(false);

            modelBuilder.Entity<sys_dept>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<sys_dept>()
                .Property(e => e.dname_short)
                .IsUnicode(false);

            modelBuilder.Entity<sys_dept>()
                .Property(e => e.dname_short_splicing)
                .IsUnicode(false);

            modelBuilder.Entity<sys_dept>()
                .Property(e => e.manager)
                .IsUnicode(false);

            modelBuilder.Entity<sys_job>()
                .Property(e => e.job)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.menu_code)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.icon_url)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.link_url)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<sys_menu_permission>()
                .Property(e => e.is_delete)
                .IsUnicode(false);

            modelBuilder.Entity<sys_role>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<sys_role>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<sys_role_menu_permission>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.employee_name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.employee_itcode)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user_role>()
                .Property(e => e.user_role_note)
                .IsUnicode(false);

            modelBuilder.Entity<view_par_file>()
                .Property(e => e.file_url)
                .IsUnicode(false);

            modelBuilder.Entity<view_par_file>()
                .Property(e => e.file_name)
                .IsUnicode(false);

            modelBuilder.Entity<view_par_file>()
                .Property(e => e.user_detailed)
                .IsUnicode(false);

            modelBuilder.Entity<view_par_file>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<view_par_file>()
                .Property(e => e.category_chil)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.employee_name)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.employee_itcode)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.job)
                .IsUnicode(false);

            modelBuilder.Entity<view_user>()
                .Property(e => e.dname_short)
                .IsUnicode(false);
        }
    }
}
