using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cafe.DbModels
{
    public partial class ReservationsContext : DbContext
    {
        public ReservationsContext()
        {
        }

        public ReservationsContext(DbContextOptions<ReservationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReservationTable> ReservationTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG373;Database=Reservations;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationTable>(entity =>
            {
                entity.Property(e => e.ContactNo).HasColumnName("Contact No.");

                entity.Property(e => e.DateTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
