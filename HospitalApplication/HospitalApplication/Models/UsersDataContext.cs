using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospitalApplication.Models
{
    public partial class UsersDataContext : DbContext
    {
        public UsersDataContext()
        {
        }

        public UsersDataContext(DbContextOptions<UsersDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logininfo> Logininfo { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= CYG325;Database=UsersData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logininfo>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
