using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface IDiscountRepos<T> : IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<Discount>> GetBrachesDiscountsAsync(int? DiscountId = null, int? BranchId = null);
    }
}
