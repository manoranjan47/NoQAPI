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
    public class TableService<T> : ITableService<T> where T : BaseEntity
    {
        private readonly ITableRepos<T> resRepos;

        public TableService(ITableRepos<T> resRepos)
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

        public async Task<IEnumerable<BranchTables>> GetBranchTablesAsync(int? TableId = null, int? BranchId = null, bool? TakeAway = null)
        {
            return  await this.resRepos.GetBranchTablesAsync(TableId, BranchId,TakeAway);
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

        public Task<bool> UpdateBranchTableAsync(BranchTables branch)
        {
            return this.resRepos.UpdateBranchTableAsync(branch);
        }
    }
}
