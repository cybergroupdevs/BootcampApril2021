using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rmsportal.Models
{
    public partial class RmsContext : DbContext
    {
        public RmsContext()
        {
        }

        public RmsContext(DbContextOptions<RmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clogin> Clogin { get; set; }
        public virtual DbSet<RmsInfo> RmsInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG298;Database=Rms;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clogin>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("CLogin");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password_")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RmsInfo>(entity =>
            {
                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("CName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Drole)
                    .IsRequired()
                    .HasColumnName("DRole")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
        }
    }
}
