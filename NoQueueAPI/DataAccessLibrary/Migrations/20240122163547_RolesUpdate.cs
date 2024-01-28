using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RolesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dbf5fba-6995-443a-bf07-374ed7808efa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "325fb1ff-1ce2-42e8-9d69-32bef31ac75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59f2f672-8661-4b74-8fe4-f03cbb890081");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc714da-4b3e-4514-9305-19867da93a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70965f19-716c-4438-8bbc-99ea3c1648f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d1acc4-73b1-45d0-ba6c-301b005f9eb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbf845a8-0b01-422c-a628-4b88a31507e7");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "BranchStaff",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

          

            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 22, 5, 46, 751, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaff_RoleId",
                table: "BranchStaff",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchStaff_AspNetRoles_RoleId",
                table: "BranchStaff",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchStaff_AspNetRoles_RoleId",
                table: "BranchStaff");

            migrationBuilder.DropIndex(
                name: "IX_BranchStaff_RoleId",
                table: "BranchStaff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1e4a9a-c010-4846-be0c-f2d84e2fe530");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2002b3f4-35c3-4632-8ce1-fd4be5f4ef1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b9f8623-3f12-4861-968a-c3878b9ea9dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d083964-6081-4048-b08d-742a9b12ea45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cfe7dc0-a3a8-41c5-a7b4-05d715967c10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "977a59b9-ce8d-426b-809a-b3250b4da9ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca5c144-62c0-4112-9475-3fb03e7b1281");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "BranchStaff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

           
            migrationBuilder.UpdateData(
                table: "PhotoCategoryMaster",
                keyColumn: "PhotoCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 2, 30, 49, 994, DateTimeKind.Local).AddTicks(9195));
        }
    }
}
