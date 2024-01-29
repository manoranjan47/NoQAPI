using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models;

public partial class StateMaster:BaseEntity
{
    [NotMapped]
    public new int Id { get; set; }
    public int StateId { get; set; }

    public int? CountryId { get; set; }

    public string StateName { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public bool? IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual CountryMaster? Country { get; set; }

    public virtual ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();
}
