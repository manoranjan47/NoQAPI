using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Models;

public partial class NoQContext : ApplicationDBContext
{
   
    public NoQContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public DbSet<ErrorHandling> ErrorHandlings { get; set; }
    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<BranchPhoto> BranchPhotos { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<CartOtherCharge> CartOtherCharges { get; set; }

    public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DistrictMaster> DistrictMasters { get; set; }

    public virtual DbSet<FoodCategory> FoodCategories { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<FoodSubCategory> FoodSubCategories { get; set; }

    public virtual DbSet<PhotoCategoryMaster> PhotoCategoryMasters { get; set; }

    public virtual DbSet<ProfileMaster> ProfileMasters { get; set; }

    public virtual DbSet<Qrdetail> Qrdetails { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<StatusMaster> StatusMasters { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<UserProfileLink> UserProfileLinks { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>(e =>
        {
            e.HasKey("LoginProvider", "ProviderKey");
            e.ToTable("AspNetUserLogins"); // Use the actual table name
        });
        modelBuilder.Entity<IdentityRoleClaim<string>>(e =>
        {
            e.HasKey("Id");
            e.ToTable("AspNetRoleClaims"); // Use the actual table name
        });
        modelBuilder.Entity<IdentityUserRole<string>>(e =>
        {
            e.HasKey("UserId", "RoleId");
            e.ToTable("AspNetUserRoles"); // Use the actual table name
        });
        modelBuilder.Entity<IdentityUserToken<string>>(e =>
        {
            e.HasKey("UserId", "LoginProvider", "Name");
            e.ToTable("AspNetUserTokens"); // Use the actual table name
        });

        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.HasKey(e => e.BankDetailId).HasName("PK__BankDeta__1741077C4891BB23");

            entity.Property(e => e.AccountHolderName).HasMaxLength(100);
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.BankBranch).HasMaxLength(100);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDefaultAccount).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__BankDetai__Branc__3E52440B");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branch__A1682FC50514ABA4");

            entity.ToTable("Branch");

            entity.Property(e => e.Address).HasMaxLength(2000);
            entity.Property(e => e.BranchCode).HasMaxLength(100);
            entity.Property(e => e.BranchName).HasMaxLength(100);
            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsPrimary).HasDefaultValueSql("((0))");
            entity.Property(e => e.Latitude).HasMaxLength(20);
            entity.Property(e => e.Longtitude).HasMaxLength(20);
            entity.Property(e => e.MapLocation).HasMaxLength(500);
            entity.Property(e => e.Mobile).HasMaxLength(30);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OtherCity).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.StatusUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Branch__CityId__2D27B809");

            entity.HasOne(d => d.Company).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Branch__CompanyI__2C3393D0");

            entity.HasOne(d => d.Country).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Branch__CountryI__300424B4");

            entity.HasOne(d => d.District).WithMany(p => p.Branches)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__Branch__District__2E1BDC42");

            entity.HasOne(d => d.State).WithMany(p => p.Branches)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Branch__StateId__2F10007B");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Branches)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Branch__Status__30F848ED");
        });

        modelBuilder.Entity<BranchPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__BranchPh__21B7B5E2147221A7");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsCoverPhoto).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Photo).HasMaxLength(100);

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchPhotos)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__BranchPho__Branc__38996AB5");

            entity.HasOne(d => d.PhotoCategory).WithMany(p => p.BranchPhotos)
                .HasForeignKey(d => d.PhotoCategoryId)
                .HasConstraintName("FK__BranchPho__Photo__398D8EEE");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B7D66C81B3");

            entity.ToTable("Cart");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DicountAmount).HasColumnType("money");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Latitude).HasMaxLength(20);
            entity.Property(e => e.Longtitude).HasMaxLength(20);
            entity.Property(e => e.OtherCharge).HasColumnType("money");
            entity.Property(e => e.PayAmount).HasColumnType("money");
            entity.Property(e => e.TaxAmount).HasColumnType("money");
            entity.Property(e => e.TaxDesc).HasMaxLength(100);
            entity.Property(e => e.TaxRate).HasColumnType("money");

            entity.HasOne(d => d.Branch).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Cart__BranchId__693CA210");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Cart__CustomerId__68487DD7");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0AAD40516B");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartItems__CartI__6EF57B66");

            entity.HasOne(d => d.FoodItem).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.FoodItemId)
                .HasConstraintName("FK__CartItems__FoodI__6FE99F9F");
        });

        modelBuilder.Entity<CartOtherCharge>(entity =>
        {
            entity.HasKey(e => e.OtherChargesId).HasName("PK__CartOthe__D1D79040608E1FB7");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Desc).HasMaxLength(100);

            entity.HasOne(d => d.Cart).WithMany(p => p.CartOtherCharges)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartOther__CartI__6C190EBB");
        });

        modelBuilder.Entity<CategoryMaster>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B826BA9A6");

            entity.ToTable("CategoryMaster");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryCode).HasMaxLength(20);
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__CityMast__F2D21B76E2F732FD");

            entity.ToTable("CityMaster");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.District).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__CityMaste__Distr__1B0907CE");
        });

        modelBuilder.Entity<CompanyMaster>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__CompanyM__2D971CAC123AB7DF");

            entity.ToTable("CompanyMaster");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mobile).HasMaxLength(30);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.StatusUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.CompanyMasters)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CompanyMa__Categ__276EDEB3");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.CompanyMasters)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__CompanyMa__Statu__286302EC");
        });

        modelBuilder.Entity<CountryMaster>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__CountryM__10D1609F7534E1FE");

            entity.ToTable("CountryMaster");

            entity.Property(e => e.CountryId).ValueGeneratedNever();
            entity.Property(e => e.CountryCode).HasMaxLength(20);
            entity.Property(e => e.CountryName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8A5DD4C7F");

            entity.ToTable("Customer");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeviceNo).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActivated).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Branch).WithMany(p => p.Customers)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Customer__Branch__6477ECF3");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6D96AC73EFDD");

            entity.ToTable("Discount");

            entity.Property(e => e.AmountLimit).HasColumnType("money");
            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DiscountType).HasMaxLength(10);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.MaxDiscountValue).HasColumnType("money");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PromoCode).HasMaxLength(20);
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTill).HasColumnType("datetime");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.Branch).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Discount__Branch__5535A963");

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.FoodCategoryId)
                .HasConstraintName("FK__Discount__FoodCa__571DF1D5");

            entity.HasOne(d => d.FoodItem).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.FoodItemId)
                .HasConstraintName("FK__Discount__FoodIt__5629CD9C");

            entity.HasOne(d => d.FoodSubCategory).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.FoodSubCategoryId)
                .HasConstraintName("FK__Discount__FoodSu__5812160E");
        });

        modelBuilder.Entity<DistrictMaster>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4C61A2A8A0B");

            entity.ToTable("DistrictMaster");

            entity.Property(e => e.DistrictId).ValueGeneratedNever();
            entity.Property(e => e.DistrictName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.State).WithMany(p => p.DistrictMasters)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__DistrictM__State__173876EA");
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.FoodCategoryId).HasName("PK__FoodCate__5451B7EB2C0261CF");

            entity.ToTable("FoodCategory");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FoodCategoryImage).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.FoodCategories)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__FoodCateg__Branc__47DBAE45");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.FoodItemId).HasName("PK__FoodItem__464DC81232ED13C2");

            entity.ToTable("FoodItem");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FoodImage).HasMaxLength(100);
            entity.Property(e => e.FoodName).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Branch).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__FoodItem__Branch__4F7CD00D");

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.FoodCategoryId)
                .HasConstraintName("FK__FoodItem__FoodCa__5070F446");

            entity.HasOne(d => d.FoodSubCategory).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.FoodSubCategoryId)
                .HasConstraintName("FK__FoodItem__FoodSu__5165187F");
        });

        modelBuilder.Entity<FoodSubCategory>(entity =>
        {
            entity.HasKey(e => e.FoodSubCategoryId).HasName("PK__FoodSubC__F70A849453AFCD2E");

            entity.ToTable("FoodSubCategory");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FoodSubCategoryImage).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.FoodSubCategories)
                .HasForeignKey(d => d.FoodCategoryId)
                .HasConstraintName("FK__FoodSubCa__FoodC__4BAC3F29");
        });

        modelBuilder.Entity<PhotoCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.PhotoCategoryId).HasName("PK__PhotoCat__7F61C6CBDF239D07");

            entity.ToTable("PhotoCategoryMaster");

            entity.Property(e => e.PhotoCategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<ProfileMaster>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__ProfileM__290C88E40BCD16AB");

            entity.ToTable("ProfileMaster");

            entity.Property(e => e.ProfileId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ProfileCode).HasMaxLength(20);
            entity.Property(e => e.ProfileName).HasMaxLength(50);
        });

        modelBuilder.Entity<Qrdetail>(entity =>
        {
            entity.HasKey(e => e.QrdetailId).HasName("PK__QRDetail__1C89A782B6529F1D");

            entity.ToTable("QRDetails");

            entity.Property(e => e.QrdetailId).HasColumnName("QRDetailId");
            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Qrcode)
                .HasMaxLength(500)
                .HasColumnName("QRCode");

            entity.HasOne(d => d.Branch).WithMany(p => p.Qrdetails)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__QRDetails__Branc__440B1D61");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__StateMas__C3BA3B3A838637A0");

            entity.ToTable("StateMaster");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.StateCode).HasMaxLength(20);
            entity.Property(e => e.StateName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.StateMasters)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__StateMast__Count__1367E606");
        });

        modelBuilder.Entity<StatusMaster>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__StatusMa__C8EE2063715A1DE4");

            entity.ToTable("StatusMaster");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserMast__1788CC4CCBE0B6A6");

            entity.ToTable("UserMaster");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mobile).HasMaxLength(30);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Pwd).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.UserMasters)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__UserMaste__Branc__5BE2A6F2");
        });

        modelBuilder.Entity<UserProfileLink>(entity =>
        {
            entity.HasKey(e => e.LinkId).HasName("PK__UserProf__2D12213582F8E6BF");

            entity.ToTable("UserProfileLink");

            entity.Property(e => e.Browser).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(100)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Profile).WithMany(p => p.UserProfileLinks)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK__UserProfi__Profi__5FB337D6");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfileLinks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserProfi__UserI__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
