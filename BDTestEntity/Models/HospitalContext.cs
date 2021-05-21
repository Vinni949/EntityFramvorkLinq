using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
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

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<HospitalOffice> HospitalOffice { get; set; }
        public virtual DbSet<HospitalType> HospitalType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientReception> PatientReception { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server = localhost; user = sa; database = Hospital; password = SAsa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TitleСategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("category_ID");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.HospitalOfficeId).HasColumnName("HospitalOffice_ID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecializationId).HasColumnName("specialization_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Doctror_Category");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Doctror_Hospital");

                entity.HasOne(d => d.HospitalOffice)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.HospitalOfficeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Doctror_HospitalOffice");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Doctror_Specialization");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalTypeId)
                    .HasColumnName("HospitalType_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Number)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.HospitalType)
                    .WithMany(p => p.Hospital)
                    .HasForeignKey(d => d.HospitalTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Hospital_HospitalType");
            });

            modelBuilder.Entity<HospitalOffice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<HospitalType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complaints)
                    .HasColumnName("complaints")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientReception>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientReception)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PatientReception_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientReception)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PatientReception_Patient");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TitleSpecialization)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
