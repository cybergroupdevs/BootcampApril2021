﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication4.Models
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
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG358\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;");
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
            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Passwords)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                
            });
        }
    }
}