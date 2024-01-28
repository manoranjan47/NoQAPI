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
    public class ManageStaffService<T> : IManageStaffService<T> where T : BaseEntity
    {
        private readonly IManageStaffRepos<T> resRepos;

        public ManageStaffService(IManageStaffRepos<T> resRepos)
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

        public async Task<IEnumerable<BranchStaff>> GetBranchStaffAsync(int? StaffId=null, int? BranchId = null, int? CompanyId = null)
        {
            return await this.resRepos.GetBranchStaffAsync(StaffId, BranchId, CompanyId);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.resRepos.GetByIdAsync(id);
        }

        public async Task<BranchStaff> GetByMobileAsync(string mobile)
        {
            return await this.resRepos.GetByMobileAsync(mobile);
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

        public Task<bool> UpdateBranchStaffAsync(BranchStaff branch)
        {
           return this.resRepos.UpdateBranchStaffAsync(branch);
        }
    }
}
