using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class BankDetail
{
    public int BankDetailId { get; set; }

    public int? BranchId { get; set; }

    public string BankName { get; set; } = null!;

    public string Ifsccode { get; set; } = null!;

    public string AccountNo { get; set; } = null!;

    public string AccountHolderName { get; set; } = null!;

    public string? BankBranch { get; set; }

    public bool? IsDefaultAccount { get; set; }

    public bool? IsVerified { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }
}
