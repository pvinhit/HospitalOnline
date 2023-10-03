using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class InitialNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2a059135-dd22-4450-93f0-09a28744683c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6b07ef4-f6c3-4cd1-9c07-f349802fc49b", "AQAAAAEAACcQAAAAEMmw3TdvPimLFrx+S65vPUZYt42eKeS3qhzXYTPH4H3ArJRCyzkVMFf0+KOZY/WlVA==" });

            migrationBuilder.UpdateData(
                table: "Appoiments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f417e6af-c47a-41db-a429-12fefe3c706a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75c244c9-d8b0-473d-a52a-6ed58b1a9f6b", "AQAAAAEAACcQAAAAELDt7saJeWI0Nby0q16DdB+zO0C5zVWmZ9tJLadVC3Q0SNiM/T+pQVzFoRTCH2N1cQ==" });

            migrationBuilder.UpdateData(
                table: "Appoiments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 1);
        }
    }
}
