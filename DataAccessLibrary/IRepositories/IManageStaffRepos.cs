using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface IManageStaffRepos<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> UpdateBranchStaffAsync(BranchStaff branch);
        Task<IEnumerable<BranchStaff>> GetBranchStaffAsync(int? StaffId=null, int? BranchId = null, int? CompanyId = null);
        public Task<BranchStaff> GetByMobileAsync(string mobile);

    }
}
