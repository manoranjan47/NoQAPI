using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RolesUpdate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02437453-ed91-4099-81b7-139c5d586d42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398948e3-e5cf-4f7e-adcc-b6ccd6215a98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5826d287-6d2e-49ad-90f0-e7dcc106c6a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ec23172-62f9-442c-a2c7-82b86bfd853b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7225fc75-59b7-46e7-90b5-ffaae2e7fe76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0aa9909-02ff-415f-9477-c32d91bec929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f20cca-ad5d-49b7-bade-78380f8eda81");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "BranchStaff",
                type: "nvarchar(max)",
                nullable: true);

           

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 22, 26, 0, 914, DateTimeKind.Local).AddTicks(1932));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "BranchStaff");

           

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 22, 24, 22, 507, DateTimeKind.Local).AddTicks(2279));
        }
    }
}
