using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirst
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<ShiftShedule> ShiftShedules { get; set; } = null!;
        public virtual DbSet<WorkShedule> WorkShedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JB1SP95\\DEV;Database=Hospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Time).HasColumnType("smalldatetime");

                entity.Property(e => e.Trouble)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ShiftShedule>(entity =>
            {
                entity.ToTable("ShiftShedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Day).HasColumnType("smalldatetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Wishes)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ShiftShedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShiftShedule_Doctors");
            });

            modelBuilder.Entity<WorkShedule>(entity =>
            {
                entity.ToTable("WorkShedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.DoctorsId).HasColumnName("DoctorsID");

                entity.Property(e => e.RecordsId).HasColumnName("RecordsID");

                entity.Property(e => e.Wishes)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Doctors)
                    .WithMany(p => p.WorkShedules)
                    .HasForeignKey(d => d.DoctorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkShedule_Doctors");

                entity.HasOne(d => d.Records)
                    .WithMany(p => p.WorkShedules)
                    .HasForeignKey(d => d.RecordsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkShedule_Records");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
