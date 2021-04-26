using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBooking.Models
{
    public partial class bookingportalContext : DbContext
    {
        public bookingportalContext()
        {
        }

        public bookingportalContext(DbContextOptions<bookingportalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG223;Database=bookingportal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("_address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Bdate)
                    .HasColumnName("bdate")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Flightname)
                    .HasColumnName("flightname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("_time")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.Adminid);

                entity.ToTable("logins");

                entity.Property(e => e.Adminid).HasColumnName("adminid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
