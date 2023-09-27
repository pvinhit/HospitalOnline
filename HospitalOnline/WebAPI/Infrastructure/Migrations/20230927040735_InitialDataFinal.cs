using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialDataFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "PatientImages",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "PatientImages",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "Gender", "LastName", "NumberBHYT", "Phone", "doctorId" },
                values: new object[,]
                {
                    { 3, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "My", "Nu", "Nguyen", "BH24612222152199", "09123456789", 1 },
                    { 4, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngoc", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 },
                    { 5, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quang", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 },
                    { 6, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quang", "Nu", "Nguyen", "BH24612222152199", "09123456789", 1 },
                    { 7, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huynh", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 },
                    { 8, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xuan", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 },
                    { 9, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thao", "Nu", "Duyen", "BH24612222152199", "09123456789", 1 },
                    { 10, "Quang Tri", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thao", "Nu", "Linh", "BH24612222152199", "09123456789", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "PatientImages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "PatientImages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

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
        }
    }
}
