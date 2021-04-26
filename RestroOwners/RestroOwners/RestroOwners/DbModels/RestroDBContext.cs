using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestroOwners.DbModels
{
    public partial class RestroDBContext : DbContext
    {
        public RestroDBContext()
        {
        }

        public RestroDBContext(DbContextOptions<RestroDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OwnerRestro> OwnerRestro { get; set; }
        public virtual DbSet<Restros> Restros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG356;Database=RestroDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerRestro>(entity =>
            {
                entity.ToTable("ownerRestro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OEmail)
                    .IsRequired()
                    .HasColumnName("oEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OPassword)
                    .IsRequired()
                    .HasColumnName("oPassword")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OUserName)
                    .IsRequired()
                    .HasColumnName("oUserName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restros>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RAddress)
                    .IsRequired()
                    .HasColumnName("rAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasColumnName("rName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RPhone).HasColumnName("rPhone");

                entity.Property(e => e.RType)
                    .IsRequired()
                    .HasColumnName("rType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
