using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ITransactionService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<Transaction>> GetTransactionAsync(int? TransactionId = null, int? BranchId = null);
        Task<IEnumerable<BranchOrders>> GetBranchOrdersAsync(int? OrderId=null, int? TransactionId = null, int? BranchId = null, int? CustomerId=null);
    }
}
