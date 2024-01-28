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
    public class UserService<T> : IUserService<T> where T : BaseEntity
    {
        private readonly IUserRepos<T> resRepos;

        public UserService(IUserRepos<T> resRepos)
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

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.resRepos.GetByIdAsync(id);
        }

        public Task<Customer> GetByMobileAsync(string mobile)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserMaster>> GetUserDataAsync(int? UserId = null, string? Mobile = null, int? BranchId = null)
        {
            return await this.resRepos.GetUserDataAsync(UserId, Mobile, BranchId);
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
    }
}
