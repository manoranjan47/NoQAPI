using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMaster",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A0B826BA9A6", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CountryMaster",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CountryM__10D1609F7534E1FE", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorHandlings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorHandlings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoCategoryMaster",
                columns: table => new
                {
                    PhotoCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhotoCat__7F61C6CBDF239D07", x => x.PhotoCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileMaster",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfileCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProfileM__290C88E40BCD16AB", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "StatusMaster",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StatusMa__C8EE2063715A1DE4", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateMaster",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StateMas__C3BA3B3A838637A0", x => x.StateId);
                    table.ForeignKey(
                        name: "FK__StateMast__Count__1367E606",
                        column: x => x.CountryId,
                        principalTable: "CountryMaster",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaster",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    StatusUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRegisteredVerified = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyM__2D971CAC123AB7DF", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK__CompanyMa__Categ__276EDEB3",
                        column: x => x.CategoryId,
                        principalTable: "CategoryMaster",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CompanyMa__Statu__286302EC",
                        column: x => x.Status,
                        principalTable: "StatusMaster",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "DistrictMaster",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__District__85FDA4C61A2A8A0B", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK__DistrictM__State__173876EA",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "CityMaster",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CityMast__F2D21B76E2F732FD", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__CityMaste__Distr__1B0907CE",
                        column: x => x.DistrictId,
                        principalTable: "DistrictMaster",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    OtherCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Longtitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MapLocation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    StatusUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRegisteredVerified = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Branch__A1682FC50514ABA4", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK__Branch__CityId__2D27B809",
                        column: x => x.CityId,
                        principalTable: "CityMaster",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Branch__CompanyI__2C3393D0",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK__Branch__CountryI__300424B4",
                        column: x => x.CountryId,
                        principalTable: "CountryMaster",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Branch__District__2E1BDC42",
                        column: x => x.DistrictId,
                        principalTable: "DistrictMaster",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Branch__StateId__2F10007B",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Branch__Status__30F848ED",
                        column: x => x.Status,
                        principalTable: "StatusMaster",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    BankDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankBranch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDefaultAccount = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BankDeta__1741077C4891BB23", x => x.BankDetailId);
                    table.ForeignKey(
                        name: "FK__BankDetai__Branc__3E52440B",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "BranchPhotos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    PhotoCategoryId = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sequenct = table.Column<int>(type: "int", nullable: true),
                    IsCoverPhoto = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BranchPh__21B7B5E2147221A7", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK__BranchPho__Branc__38996AB5",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK__BranchPho__Photo__398D8EEE",
                        column: x => x.PhotoCategoryId,
                        principalTable: "PhotoCategoryMaster",
                        principalColumn: "PhotoCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "BranchStaff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRegisteredVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStaff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_BranchStaff_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchStaff_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchStaff_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchTables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableQrPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableQrUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    IsTakeAway = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_BranchTables_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    IsRegisteredVerified = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64D8A5DD4C7F", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK__Customer__Branch__6477ECF3",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodCategoryImage = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FoodCate__5451B7EB2C0261CF", x => x.FoodCategoryId);
                    table.ForeignKey(
                        name: "FK__FoodCateg__Branc__47DBAE45",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "QRDetails",
                columns: table => new
                {
                    QRDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    TableNo = table.Column<int>(type: "int", nullable: true),
                    QRCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QRDetail__1C89A782B6529F1D", x => x.QRDetailId);
                    table.ForeignKey(
                        name: "FK__QRDetails__Branc__440B1D61",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pwd = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserMast__1788CC4CCBE0B6A6", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserMaste__Branc__5BE2A6F2",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    OtherCharge = table.Column<decimal>(type: "money", nullable: true),
                    DicountAmount = table.Column<decimal>(type: "money", nullable: true),
                    TaxDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxRate = table.Column<decimal>(type: "money", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "money", nullable: true),
                    PayAmount = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Longtitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__51BCD7B7D66C81B3", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK__Cart__BranchId__693CA210",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "FoodSubCategory",
                columns: table => new
                {
                    FoodSubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodSubCategoryImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FoodSubC__F70A849453AFCD2E", x => x.FoodSubCategoryId);
                    table.ForeignKey(
                        name: "FK__FoodSubCa__FoodC__4BAC3F29",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "FoodCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "UserProfileLink",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProf__2D12213582F8E6BF", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK__UserProfi__Profi__5FB337D6",
                        column: x => x.ProfileId,
                        principalTable: "ProfileMaster",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK__UserProfi__UserI__60A75C0F",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CartOtherCharges",
                columns: table => new
                {
                    OtherChargesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartOthe__D1D79040608E1FB7", x => x.OtherChargesId);
                    table.ForeignKey(
                        name: "FK__CartOther__CartI__6C190EBB",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Transactions_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Transactions_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: true),
                    FoodSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    FoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    FoodImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    IsNonVeg = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FoodItem__464DC81232ED13C2", x => x.FoodItemId);
                    table.ForeignKey(
                        name: "FK__FoodItem__Branch__4F7CD00D",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK__FoodItem__FoodCa__5070F446",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "FoodCategoryId");
                    table.ForeignKey(
                        name: "FK__FoodItem__FoodSu__5165187F",
                        column: x => x.FoodSubCategoryId,
                        principalTable: "FoodSubCategory",
                        principalColumn: "FoodSubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "BranchOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_BranchOrders_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrders_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_BranchOrders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_BranchOrders_StatusMaster_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusMaster",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrders_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    FoodItemId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartItem__488B0B0AAD40516B", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK__CartItems__CartI__6EF57B66",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK__CartItems__FoodI__6FE99F9F",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "FoodItemId");
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    FoodItemId = table.Column<int>(type: "int", nullable: true),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: true),
                    FoodSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    AmountLimit = table.Column<decimal>(type: "money", nullable: true),
                    PromoCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Value = table.Column<decimal>(type: "money", nullable: true),
                    MaxDiscountValue = table.Column<decimal>(type: "money", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidTill = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__E43F6D96AC73EFDD", x => x.DiscountId);
                    table.ForeignKey(
                        name: "FK__Discount__Branch__5535A963",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK__Discount__FoodCa__571DF1D5",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "FoodCategoryId");
                    table.ForeignKey(
                        name: "FK__Discount__FoodIt__5629CD9C",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "FoodItemId");
                    table.ForeignKey(
                        name: "FK__Discount__FoodSu__5812160E",
                        column: x => x.FoodSubCategoryId,
                        principalTable: "FoodSubCategory",
                        principalColumn: "FoodSubCategoryId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22084e7a-8bd0-4bc0-9645-ce60f0d5eefa", "3", "Customer", "Customer" },
                    { "31a2a9b8-8a5b-4c32-942d-af3457f873b5", "2", "User", "User" },
                    { "5c75e693-1f4a-4a34-bb65-db5fbc5ee93d", "4", "Branch Head", "BranchHead" },
                    { "8cedbd54-22aa-4c69-84b0-3026c2411103", "6", "Kitchen Supervisor", "KitchenSupervisor" },
                    { "9d44ca37-bfb4-4b3a-be9a-00dfc81a735a", "1", "CompanyAdmin", "CompanyAdmin" },
                    { "be48a133-ce33-4edd-9af3-114f3d7e2f9b", "5", "Cashier", "Cashier" },
                    { "c220ae5c-79a5-4059-9164-5443f107e4b9", "7", "Steward", "Steward" }
                });

            migrationBuilder.InsertData(
                table: "CategoryMaster",
                columns: new[] { "CategoryId", "CategoryCode", "CategoryName", "Id", "IsActive", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "r", "Restaurants", 1, true, false },
                    { 2, "h", "Hotel", 2, true, false }
                });

            migrationBuilder.InsertData(
                table: "PhotoCategoryMaster",
                columns: new[] { "PhotoCategoryId", "CategoryName", "CreatedDate", "Id", "IsActive", "IsDeleted" },
                values: new object[] { 1, "Branch", new DateTime(2024, 1, 30, 0, 25, 20, 881, DateTimeKind.Local).AddTicks(3845), 1, true, false });

            migrationBuilder.InsertData(
                table: "StatusMaster",
                columns: new[] { "StatusId", "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 0, true, false, "Active" },
                    { 2, 0, true, false, "InActive" },
                    { 3, 0, true, false, "Completed" },
                    { 4, 0, true, false, "Processing" },
                    { 5, 0, true, false, "On Hold" },
                    { 6, 0, true, false, "Pending" },
                    { 7, 0, true, false, "Accepted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BranchId",
                table: "BankDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CityId",
                table: "Branch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CountryId",
                table: "Branch",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DistrictId",
                table: "Branch",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_StateId",
                table: "Branch",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Status",
                table: "Branch",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_BranchId",
                table: "BranchOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_CartId",
                table: "BranchOrders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_CustomerId",
                table: "BranchOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_StatusId",
                table: "BranchOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_TransactionId",
                table: "BranchOrders",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchPhotos_BranchId",
                table: "BranchPhotos",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchPhotos_PhotoCategoryId",
                table: "BranchPhotos",
                column: "PhotoCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaff_BranchId",
                table: "BranchStaff",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaff_CompanyId",
                table: "BranchStaff",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchStaff_RoleId",
                table: "BranchStaff",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchTables_BranchId",
                table: "BranchTables",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BranchId",
                table: "Cart",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FoodItemId",
                table: "CartItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartOtherCharges_CartId",
                table: "CartOtherCharges",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMaster_DistrictId",
                table: "CityMaster",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_CategoryId",
                table: "CompanyMaster",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_Status",
                table: "CompanyMaster",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BranchId",
                table: "Customer",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_BranchId",
                table: "Discount",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_FoodCategoryId",
                table: "Discount",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_FoodItemId",
                table: "Discount",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_FoodSubCategoryId",
                table: "Discount",
                column: "FoodSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictMaster_StateId",
                table: "DistrictMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategory_BranchId",
                table: "FoodCategory",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_BranchId",
                table: "FoodItem",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_FoodCategoryId",
                table: "FoodItem",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_FoodSubCategoryId",
                table: "FoodItem",
                column: "FoodSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSubCategory_FoodCategoryId",
                table: "FoodSubCategory",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QRDetails_BranchId",
                table: "QRDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_StateMaster_CountryId",
                table: "StateMaster",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchId",
                table: "Transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartId",
                table: "Transactions",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_BranchId",
                table: "UserMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLink_ProfileId",
                table: "UserProfileLink",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLink_UserId",
                table: "UserProfileLink",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "BranchOrders");

            migrationBuilder.DropTable(
                name: "BranchPhotos");

            migrationBuilder.DropTable(
                name: "BranchStaff");

            migrationBuilder.DropTable(
                name: "BranchTables");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CartOtherCharges");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "ErrorHandlings");

            migrationBuilder.DropTable(
                name: "QRDetails");

            migrationBuilder.DropTable(
                name: "UserProfileLink");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "PhotoCategoryMaster");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "ProfileMaster");

            migrationBuilder.DropTable(
                name: "UserMaster");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "FoodSubCategory");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "FoodCategory");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "CityMaster");

            migrationBuilder.DropTable(
                name: "CompanyMaster");

            migrationBuilder.DropTable(
                name: "DistrictMaster");

            migrationBuilder.DropTable(
                name: "CategoryMaster");

            migrationBuilder.DropTable(
                name: "StatusMaster");

            migrationBuilder.DropTable(
                name: "StateMaster");

            migrationBuilder.DropTable(
                name: "CountryMaster");
        }
    }
}
