using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RolesUpdate121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05316937-60c2-4e71-ab7c-117ced27bb7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26b3b28d-e5d6-48bd-9e5e-7cc5e5a5c785");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46618297-527d-41b5-9304-b27dc7fa9a4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3cb92f-d9b5-40e3-a2e1-d7136fbae2eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc209f5-0e42-430b-9c25-c49a3446d3dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c831a5f-3c78-44d8-bed0-badcb27c341a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e89f3da-2729-4f7d-b5f9-f064910df5f7");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "BranchStaff",
                type: "nvarchar(max)",
                nullable: true);

           

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 22, 55, 56, 833, DateTimeKind.Local).AddTicks(5908));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21c3f500-e0de-4d67-8c67-49e728783677");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350d687e-6b9c-4e48-9c3e-7438e22f9a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "528dea47-5a3c-40ae-98ed-2269a8b1a18c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eb71b34-c18f-478a-b52b-479acf6b1233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b868da46-e4d2-4e3a-a9e2-630446a1f75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9c8d822-a1a5-460e-9b6d-e430e799fff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f5b332-60f4-4b9e-aad9-b307f78bebbe");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "BranchStaff");

           

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 22, 26, 0, 914, DateTimeKind.Local).AddTicks(1932));
        }
    }
}
