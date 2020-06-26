using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<HospitalPhone> HospitalPhones { get; set; }

        public DbSet<Ward> Wards { get; set; }

        public DbSet<Lab> Labs { get; set; }

        public DbSet<LabPhone> LabPhones { get; set; }

        public DbSet<HospitalLab> HospitalLabs { get; set; }


        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<WardStaff> WardStaffs { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AnalysisLab> AnalysisLabs { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<DiagnosisPatient> DiagnosisPatients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HospitalPhone>()
                .HasKey(x => new { x.HospitalId, x.PhoneId });

            modelBuilder.Entity<LabPhone>()
                .HasKey(x => new { x.LabId, x.PhoneId });

            modelBuilder.Entity<HospitalLab>()
                .HasKey(x => new { x.HospitalId, x.LabId });
            modelBuilder.Entity<DoctorHospitel>()
               .HasKey(x => new { x.HospitalId, x.DoctorId });

            modelBuilder.Entity<WardStaff>()
               .HasKey(x => new { x.WardId, x.StaffId });
            modelBuilder.Entity<DoctorPatient>()
               .HasKey(x => new { x.DoctorId, x.PatientId });
            modelBuilder.Entity<Analysis>()
               .HasKey(x => new { x.AnalysisId, x.PatientId });
            modelBuilder.Entity<AnalysisLab>()
               .HasKey(x => new { x.AnalysisId, x.LabId });
            modelBuilder.Entity<DiagnosisPatient>()
              .HasKey(x => new { x.DiagnosisId, x.PatientId });


        }


        public DbSet<Backend5.Models.DoctorHospitel> DoctorHospitel { get; set; }
        public DbSet<Backend5.Models.DoctorPatient> DoctorPatients { get; set; }
        
    }
}
