using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models;

public partial class DistrictMaster:BaseEntity
{
    [NotMapped]
    public new int Id { get; set; }
    public int DistrictId { get; set; }

    public int? StateId { get; set; }

    public string DistrictName { get; set; } = null!;

    public bool? IsActive { get; set; }
    public DateTime
        ? CreatedDate
    { get; set; }
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual StateMaster? State { get; set; }
}
