using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models;

public partial class Qrdetail
{
    public int QrdetailId { get; set; }

    public int? BranchId { get; set; }

    public int? TableNo { get; set; }

    public string? Qrcode { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual Branch? Branch { get; set; }
}
