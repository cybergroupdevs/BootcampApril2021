using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace assignment_net1.Models
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentInfo> StudentInfo { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<EducationInfo> EducationInfo { get; set; }
        public virtual DbSet<ContactInfo> ContactInfo { get; set; }
        public virtual DbSet<ImageInfo> ImageInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CSMD8BJ\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EducationInfo>(entity =>
            {
                entity.Property(e => e.Year)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageInfo>(entity =>
            {
                entity.Property(e => e.ImgName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgData)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
