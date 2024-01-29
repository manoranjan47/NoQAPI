using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class TransactionService<T> : ITransactionService<T> where T : BaseEntity
    {
        private readonly ITransactionRepos<T> resRepos;

        public TransactionService(ITransactionRepos<T> resRepos)
        {
            this.resRepos = resRepos;
        }

        public void DeleteAsync(int id)
        {
            this.resRepos.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.resRepos.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllCategoryAsync()
        {
            return await this.resRepos.GetAllAsync();
        }
        public async Task<IEnumerable<Transaction>> GetTransactionAsync(int? TransactionId = null, int? BranchId = null)
        {
            return await this.resRepos.GetTransactionAsync(TransactionId, BranchId);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await this.resRepos.GetByIdAsync(id);
        }


        public void InsertAsync(T entity)
        {
            this.resRepos.InsertAsync(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.resRepos.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            this.resRepos.UpdateAsync(entity);
        }

        public async Task<IEnumerable<BranchOrders>> GetBranchOrdersAsync(int? OrderId=null, int? TransactionId = null, int? BranchId = null, int? CustomerId = null)
        {
            return await this.resRepos.GetBranchOrdersAsync(OrderId,TransactionId,BranchId,CustomerId);
        }
    }
}
