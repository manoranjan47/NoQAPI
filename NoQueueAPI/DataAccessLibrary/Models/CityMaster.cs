using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models;

public partial class CityMaster:BaseEntity
{
    [NotMapped]
    public new int Id { get; set; }
    public int CityId { get; set; }

    public int? DistrictId { get; set; }

    public string CityName { get; set; } = null!;

    public bool? IsActive { get; set; }
    public DateTime? CreatedDate{ get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual DistrictMaster? District { get; set; }
}
