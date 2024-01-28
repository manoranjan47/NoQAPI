using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models;

public partial class CompanyMaster:BaseEntity
{
    public int CompanyId { get; set; }

    public int CategoryId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Mobile { get; set; } = null!;
    public string? LoginId { get; set; }    
    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? ContactPerson { get; set; } = null!;

    public int? Status { get; set; }

    public int? StatusUpdatedBy { get; set; }

    public DateTime? StatusUpdatedDate { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public string? Browser { get; set; }

    public virtual ICollection<Branch>? Branches { get; set; } = new List<Branch>();
    [NotMapped]
    public virtual CategoryMaster Category { get; set; }

    public virtual StatusMaster? StatusNavigation { get; set; }
    public bool IsRegisteredVerified { get; set; }

}
