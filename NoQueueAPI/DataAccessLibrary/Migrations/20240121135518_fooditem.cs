using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class fooditem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsNonVeg",
                table: "FoodItem",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02460289-f507-4f3b-a66b-fcd186cba9e7", "3", "Customer", "Customer" },
                    { "22434ade-ef66-470a-adfb-bfe31c891d25", "4", "Staff", "Staff" },
                    { "a393ba94-e741-4ffa-9d4c-92e71ac5b91d", "1", "CompanyAdmin", "CompanyAdmin" },
                    { "f15a1403-b2df-4646-82a7-ba128ff03368", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 25, 18, 348, DateTimeKind.Local).AddTicks(4856));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02460289-f507-4f3b-a66b-fcd186cba9e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22434ade-ef66-470a-adfb-bfe31c891d25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a393ba94-e741-4ffa-9d4c-92e71ac5b91d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f15a1403-b2df-4646-82a7-ba128ff03368");

            migrationBuilder.DropColumn(
                name: "IsNonVeg",
                table: "FoodItem");

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
    }
}
