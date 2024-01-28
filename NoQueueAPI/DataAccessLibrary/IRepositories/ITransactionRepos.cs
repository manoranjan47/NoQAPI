using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ITransactionRepos<T> : IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<Transaction>> GetTransactionAsync(int? DiscountId = null, int? BranchId = null);
        Task<IEnumerable<BranchOrders>> GetBranchOrdersAsync(int? OrderId=null, int? TransactionId = null, int? BranchId = null, int? CustomerId=null);
    }
}
