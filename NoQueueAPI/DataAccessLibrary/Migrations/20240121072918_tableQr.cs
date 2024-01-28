using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class tableQr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d433e33-5818-45cf-ab89-b79e340d6969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dbca646-b466-4339-a404-bb9ba81b489f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af70f7b2-8343-4e95-9d40-c33741acc680");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e531fc0f-3bfe-49dc-b21e-959ded2c00f6");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BranchTables");

            migrationBuilder.AddColumn<bool>(
                name: "IsTakeAway",
                table: "BranchTables",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "225bafad-1762-420c-8201-254e9125171d", "4", "Staff", "Staff" },
                    { "271efe9b-cb2e-4dec-996d-255c48326093", "3", "Customer", "Customer" },
                    { "79371f8d-796a-40ff-80b0-75b17b995f1c", "1", "CompanyAdmin", "CompanyAdmin" },
                    { "9b653bf3-fc05-46e0-981a-7a9e0a89c234", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 12, 59, 17, 707, DateTimeKind.Local).AddTicks(4111));


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "225bafad-1762-420c-8201-254e9125171d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "271efe9b-cb2e-4dec-996d-255c48326093");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79371f8d-796a-40ff-80b0-75b17b995f1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b653bf3-fc05-46e0-981a-7a9e0a89c234");

          

            migrationBuilder.DropColumn(
                name: "IsTakeAway",
                table: "BranchTables");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BranchTables",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d433e33-5818-45cf-ab89-b79e340d6969", "1", "CompanyAdmin", "CompanyAdmin" },
                    { "8dbca646-b466-4339-a404-bb9ba81b489f", "3", "Customer", "Customer" },
                    { "af70f7b2-8343-4e95-9d40-c33741acc680", "4", "Staff", "Staff" },
                    { "e531fc0f-3bfe-49dc-b21e-959ded2c00f6", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 14, 34, 50, 600, DateTimeKind.Local).AddTicks(6848));
        }
    }
}
