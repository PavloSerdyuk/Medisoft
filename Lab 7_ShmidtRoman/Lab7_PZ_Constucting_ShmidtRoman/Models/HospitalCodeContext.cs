using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab7_PZ_Constucting_ShmidtRoman
{
    public partial class HospitalCodeContext : DbContext
    {

        public HospitalCodeContext(DbContextOptions<HospitalCodeContext> options)
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-JB1SP95\\DEV;Database=HospitalCode;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShiftShedule>(entity =>
            {
                entity.HasIndex(e => e.DoctorCodeId, "IX_ShiftShedules_DoctorCodeId");

                entity.HasOne(d => d.DoctorCode)
                    .WithMany(p => p.ShiftShedules)
                    .HasForeignKey(d => d.DoctorCodeId);
            });

            modelBuilder.Entity<WorkShedule>(entity =>
            {
                entity.HasIndex(e => e.RecordCodeId, "IX_WorkShedules_RecordCodeId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.WorkShedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkShedules_Doctors");

                entity.HasOne(d => d.RecordCode)
                    .WithMany(p => p.WorkShedules)
                    .HasForeignKey(d => d.RecordCodeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
