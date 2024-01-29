using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public partial class BranchPhotoDTO
    {

        public int? BranchId { get; set; }

        public int? PhotoCategoryId { get; set; }

        public string? Photo { get; set; }

        public int? Sequenct { get; set; }

        public bool? IsCoverPhoto { get; set; }

        public string? Description { get; set; }
    }
}
