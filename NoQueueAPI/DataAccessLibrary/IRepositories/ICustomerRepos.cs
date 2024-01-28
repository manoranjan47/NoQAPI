using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ICustomerRepos<T> : IRepository<T> where T : BaseEntity
    {
        //additional functions to be defined here
        Task<IEnumerable<Customer>> GetCustomerAsync(int? CustomerId = null, string? Mobile = null, int? BranchId = null);
        public Task<Customer> GetByMobileAsync(string mobile);

    }
}
