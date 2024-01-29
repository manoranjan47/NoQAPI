using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ICompanyRepos<T>:IRepository<T> where T : BaseEntity
    {
        //additional functions to be defined here
        public Task<CompanyMaster> GetByMobileAsync(string mobile);
        public Task<Branch> GetBranchByMobileAsync(string mobile);
        public Task<IEnumerable<CompanyMaster>> GetAllCompanyAsync(int? CompanyId = null, int? BranchId = null, string? Mobile = null, int? Id = null);

    }
}
