using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class InitialPatientImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false),
                    patientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientImages_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7c0e35aa-a8d5-4c2a-b33a-a53fd858e4d5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a474f0ff-23b0-43e9-a55f-1968e38c3471", "AQAAAAEAACcQAAAAELv0PQhqu8A8x0QAIFyvB8x5xP9fvJ1NTozA9MNyLVmqPRuBi5OaR/5WnsC1dMB3+w==" });

            migrationBuilder.UpdateData(
                table: "Appoiments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_PatientImages_patientId",
                table: "PatientImages",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9722bc95-de6b-4559-8a9d-40baca440d92");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e9c924f-2820-4a12-9b31-dbbfcd0cb96a", "AQAAAAEAACcQAAAAEG11oUBvuAlOhrlPmeqVpCmo8XmdEBfB9PuBb3To1fZdpvXHWXXDluQAAdfx4UDFXg==" });

            migrationBuilder.UpdateData(
                table: "Appoiments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 1);
        }
    }
}
