using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class InitialDbPosgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NumberBHYT = table.Column<string>(nullable: true),
                    doctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appoiments",
                columns: table => new
                {
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoiments", x => new { x.doctorId, x.patientId });
                    table.ForeignKey(
                        name: "FK_Appoiments_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appoiments_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    Prescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName", "Phone", "Specialty" },
                values: new object[] { 1, "Tran", "Loi", "0932123587", "Da Lieu" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "Gender", "LastName", "NumberBHYT", "Phone", "doctorId" },
                values: new object[,]
                {
                    { 1, "Hue", new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pham", "Nam", "Vinh", "BH24612222152122", "0334787899", 1 },
                    { 2, "Quang Nam", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "My", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 }
                });

            migrationBuilder.InsertData(
                table: "Appoiments",
                columns: new[] { "doctorId", "patientId", "AppointmentDate", "AppointmentTime", "Id", "Status" },
                values: new object[] { 1, 2, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, "Success" });

            migrationBuilder.CreateIndex(
                name: "IX_Appoiments_patientId",
                table: "Appoiments",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_patientId",
                table: "MedicalHistories",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_doctorId",
                table: "Patients",
                column: "doctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appoiments");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
