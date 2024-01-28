using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ICustomerService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<Customer>> GetCustomerAsync(int? CustomerId = null, string? Mobile = null, int? BranchId = null);
        public Task<Customer> GetByMobileAsync(string mobile);

    }
}
