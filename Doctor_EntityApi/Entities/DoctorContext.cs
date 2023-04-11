using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Entities;

public partial class DoctorContext : DbContext
{
    public DoctorContext()
    {
    }

    public DoctorContext(DbContextOptions<DoctorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=tcp:poseidonserver.database.windows.net,1433;initial catalog=Doctor;persist security info=false;user id=poseidon;password=Program@123;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__doctor__A9D10535A9C3590D");

            entity.ToTable("doctor");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dept).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<DoctorAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__doctor_a__86E3A801CD73E114");

            entity.ToTable("doctor_availability");

            entity.Property(e => e.AvailabilityId).HasColumnName("availability_id");
            entity.Property(e => e.AvailableFrom)
                .IsUnicode(false)
                .HasColumnName("available_from");
            entity.Property(e => e.AvailableTo)
                .IsUnicode(false)
                .HasColumnName("available_to");
            entity.Property(e => e.DoctorEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("doctor_email");
            entity.Property(e => e.ScheduleStatus).HasColumnName("schedule_status");

            entity.HasOne(d => d.DoctorEmailNavigation).WithMany(p => p.DoctorAvailabilities)
                .HasForeignKey(d => d.DoctorEmail)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__doctor_av__docto__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
