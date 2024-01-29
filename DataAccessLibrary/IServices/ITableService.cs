using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ITableService<T> : IService<T> where T : BaseEntity
    {
        public Task<bool> UpdateBranchTableAsync(BranchTables branch);
        Task<IEnumerable<BranchTables>> GetBranchTablesAsync(int? TableId = null, int? BranchId = null, bool? TakeAway = null);
    }
}
