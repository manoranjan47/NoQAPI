using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface IUserRepos<T> : IRepository<T> where T : BaseEntity
    {
        //additional functions to be defined here
        public Task<Customer> GetByMobileAsync(string mobile);
        Task<IEnumerable<UserMaster>> GetUserDataAsync(int? UserId = null, string? Mobile = null, int? BranchId = null);
    }
}
