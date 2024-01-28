using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public int? CompanyId { get; set; }

    public string BranchName { get; set; } = null!;

    public string BranchCode { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string ContactPerson { get; set; } = null!;

    public string? Address { get; set; }

    public int? CityId { get; set; }

    public string? OtherCity { get; set; }

    public int? DistrictId { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public int? PinCode { get; set; }

    public string? Latitude { get; set; }

    public string? Longtitude { get; set; }

    public string? MapLocation { get; set; }

    public int? Status { get; set; }

    public int? StatusUpdatedBy { get; set; }

    public DateTime? StatusUpdatedDate { get; set; }

    public string? Remarks { get; set; }

    public bool? IsPrimary { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual ICollection<BankDetail> BankDetails { get; set; } = new List<BankDetail>();

    public virtual ICollection<BranchPhoto> BranchPhotos { get; set; } = new List<BranchPhoto>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual CityMaster? City { get; set; }

    public virtual CompanyMaster? Company { get; set; }

    public virtual CountryMaster? Country { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual DistrictMaster? District { get; set; }

    public virtual ICollection<FoodCategory> FoodCategories { get; set; } = new List<FoodCategory>();

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

    public virtual ICollection<Qrdetail> Qrdetails { get; set; } = new List<Qrdetail>();

    public virtual StateMaster? State { get; set; }

    public virtual StatusMaster? StatusNavigation { get; set; }

    public virtual ICollection<UserMaster> UserMasters { get; set; } = new List<UserMaster>();
}
