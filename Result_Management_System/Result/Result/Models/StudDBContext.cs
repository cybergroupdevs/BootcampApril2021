using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Result.Models
{
    public partial class StudDBContext : DbContext
    {
        public StudDBContext()
        {
        }

        public StudDBContext(DbContextOptions<StudDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<StudInfo> StudInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG225;Database=StudDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("loginInfo");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<StudInfo>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
