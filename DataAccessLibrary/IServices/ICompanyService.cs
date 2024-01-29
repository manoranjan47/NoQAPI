using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ICompanyService<T> : IService<T> where T : BaseEntity
    {
        public Task<CompanyMaster> GetByMobileAsync(string mobile);
        public Task<Branch> GetBranchByMobileAsync(string mobile);
        public Task<IEnumerable<CompanyMaster>> GetAllCompanyAsync(int? CompanyId = null, int? CategoryId = null, string? Mobile = null, int? Id = null);
    }
}
