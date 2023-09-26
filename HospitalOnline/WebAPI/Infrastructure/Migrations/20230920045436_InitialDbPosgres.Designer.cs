﻿// <auto-generated />
using System;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230920045436_InitialDbPosgres")]
    partial class InitialDbPosgres
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Demo.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Specialty")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Tran",
                            LastName = "Loi",
                            Phone = "0932123587",
                            Specialty = "Da Lieu"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Appointment", b =>
                {
                    b.Property<int>("doctorId")
                        .HasColumnType("integer");

                    b.Property<int>("patientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Status")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("doctorId", "patientId");

                    b.HasIndex("patientId");

                    b.ToTable("Appoiments");

                    b.HasData(
                        new
                        {
                            doctorId = 1,
                            patientId = 2,
                            AppointmentDate = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentTime = new DateTime(2023, 9, 20, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            Id = 1,
                            Status = "Success"
                        });
                });

            modelBuilder.Entity("Domain.Entity.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Diagnosis")
                        .HasColumnType("text");

                    b.Property<string>("Prescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("doctorId")
                        .HasColumnType("integer");

                    b.Property<int>("patientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("patientId");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("Domain.Entity.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("NumberBHYT")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("doctorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Hue",
                            DateOfBirth = new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pham",
                            Gender = "Nam",
                            LastName = "Vinh",
                            NumberBHYT = "BH24612222152122",
                            Phone = "0334787899",
                            doctorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Quang Nam",
                            DateOfBirth = new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "My",
                            Gender = "Nu",
                            LastName = "Duyen",
                            NumberBHYT = "BH24612222152199",
                            Phone = "09123456789",
                            doctorId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entity.Appointment", b =>
                {
                    b.HasOne("Demo.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.MedicalHistory", b =>
                {
                    b.HasOne("Domain.Entity.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Patient", b =>
                {
                    b.HasOne("Demo.Entities.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}