﻿// <auto-generated />
using Backend5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Backend5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200421210155_addAnaalysis")]
    partial class addAnaalysis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend5.Models.Analysis", b =>
                {
                    b.Property<int>("AnalysisId");

                    b.Property<int>("PatientId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.HasKey("AnalysisId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("Backend5.Models.AnalysisLab", b =>
                {
                    b.Property<int>("AnalysisId");

                    b.Property<int>("LabId");

                    b.Property<int?>("AnalysisId1");

                    b.Property<int?>("AnalysisPatientId");

                    b.HasKey("AnalysisId", "LabId");

                    b.HasIndex("LabId");

                    b.HasIndex("AnalysisId1", "AnalysisPatientId");

                    b.ToTable("AnalysisLabs");
                });

            modelBuilder.Entity("Backend5.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Backend5.Models.DoctorHospitel", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("DoctorId");

                    b.HasKey("HospitalId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorHospitel");
                });

            modelBuilder.Entity("Backend5.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("Backend5.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Backend5.Models.HospitalLab", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("LabId");

                    b.HasKey("HospitalId", "LabId");

                    b.HasIndex("LabId");

                    b.ToTable("HospitalLabs");
                });

            modelBuilder.Entity("Backend5.Models.HospitalPhone", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("PhoneId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("HospitalId", "PhoneId");

                    b.ToTable("HospitalPhones");
                });

            modelBuilder.Entity("Backend5.Models.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("Backend5.Models.LabPhone", b =>
                {
                    b.Property<int>("LabId");

                    b.Property<int>("PhoneId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("LabId", "PhoneId");

                    b.ToTable("LabPhones");
                });

            modelBuilder.Entity("Backend5.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Gender");

                    b.Property<string>("PatientName");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Backend5.Models.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HospitalId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("Backend5.Models.WardStaff", b =>
                {
                    b.Property<int>("WardId");

                    b.Property<int>("StaffId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Position");

                    b.HasKey("WardId", "StaffId");

                    b.ToTable("WardStaffs");
                });

            modelBuilder.Entity("Backend5.Models.Analysis", b =>
                {
                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("Analyses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.AnalysisLab", b =>
                {
                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("AnalysisLabs")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Analysis", "Analysis")
                        .WithMany("AnalysisLabs")
                        .HasForeignKey("AnalysisId1", "AnalysisPatientId");
                });

            modelBuilder.Entity("Backend5.Models.DoctorHospitel", b =>
                {
                    b.HasOne("Backend5.Models.Doctor", "Doctor")
                        .WithMany("Hospitels")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.DoctorPatient", b =>
                {
                    b.HasOne("Backend5.Models.Doctor", "Doctor")
                        .WithMany("doctorPatients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("doctorPatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.HospitalLab", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Labs")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("Hospitals")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.HospitalPhone", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Phones")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.LabPhone", b =>
                {
                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("Phones")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.Ward", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Wards")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.WardStaff", b =>
                {
                    b.HasOne("Backend5.Models.Ward", "Ward")
                        .WithMany("WardStaff")
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
