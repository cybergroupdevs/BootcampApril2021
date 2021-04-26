using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROJECT_COLLEGE.Models
{
    public partial class CollegedbContext : DbContext
    {
        public CollegedbContext()
        {
        }

        public CollegedbContext(DbContextOptions<CollegedbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DepartmentTbl> DepartmentTbl { get; set; }
        public virtual DbSet<StudentTable> StudentTable { get; set; }
        public virtual DbSet<TeacherTbl> TeacherTbl { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG306\\SQLEXPRESS;Database=Collegedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentTbl>(entity =>
            {
                entity.HasKey(e => e.DepName);

                entity.Property(e => e.DepName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DepDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<StudentTable>(entity =>
            {
                entity.HasKey(e => e.StdId);

                entity.Property(e => e.StdDep)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdDob)
                    .IsRequired()
                    .HasColumnName("StdDOB")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdFees)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdGender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StdName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeacherTbl>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.Property(e => e.TeacherId).ValueGeneratedNever();

                entity.Property(e => e.TeacherAdd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherDep)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherGender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
