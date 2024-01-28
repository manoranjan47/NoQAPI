using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchOrders_StateMaster_StateId",
                table: "BranchOrders");

            migrationBuilder.DropIndex(
                name: "IX_BranchOrders_StateId",
                table: "BranchOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02d65255-a6a7-428c-b0ac-a979a64459bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3836f4a7-37f0-4948-9ca2-32d6f0cfdacc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d65ff65f-251a-4540-92b7-a2f961cb6cb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb1993bc-ce44-4e1b-9688-5edeab6f6a4c");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "BranchOrders");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cart",
                type: "bit",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_StatusId",
                table: "BranchOrders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchOrders_StatusMaster_StatusId",
                table: "BranchOrders",
                column: "StatusId",
                principalTable: "StatusMaster",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchOrders_StatusMaster_StatusId",
                table: "BranchOrders");

            migrationBuilder.DropIndex(
                name: "IX_BranchOrders_StatusId",
                table: "BranchOrders");

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

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cart",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "BranchOrders",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02d65255-a6a7-428c-b0ac-a979a64459bb", "1", "CompanyAdmin", "CompanyAdmin" },
                    { "3836f4a7-37f0-4948-9ca2-32d6f0cfdacc", "3", "Customer", "Customer" },
                    { "d65ff65f-251a-4540-92b7-a2f961cb6cb7", "4", "Staff", "Staff" },
                    { "fb1993bc-ce44-4e1b-9688-5edeab6f6a4c", "2", "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 1, 29, 44, 576, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_StateId",
                table: "BranchOrders",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchOrders_StateMaster_StateId",
                table: "BranchOrders",
                column: "StateId",
                principalTable: "StateMaster",
                principalColumn: "StateId");
        }
    }
}
