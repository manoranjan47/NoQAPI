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
    public class RestaurantService<T> : IRestaurantService<T> where T : BaseEntity
    {
        private readonly IRestaurantRepository<T> resRepos;

        public RestaurantService(IRestaurantRepository<T> resRepos)
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

        public async Task<IEnumerable<BankDetail>> GetAllBankDetailAsync(int? BankDetailId = null, int? BranchId = null)
        {
            return await this.resRepos.GetAllBankDetailAsync(BankDetailId, BranchId);
        }

        public async Task<IEnumerable<Branch>> GetAllBrachesAsync(int? companyId = null, int? BranchId = null)
        {
            return await this.resRepos.GetAllBrachesAsync(companyId,BranchId);
        }

        public async Task<IEnumerable<T>> GetAllCategoryAsync()
        {
            return await this.resRepos.GetAllAsync();
        }

        public async Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync(int? FoodItemId = null, int? BranchId = null, int? FoodCategoryId = null, int? FoodSubCategoryId = null)
        {
            return await this.resRepos.GetAllFoodItemsAsync(FoodItemId, BranchId, FoodCategoryId, FoodSubCategoryId);
        }

        public async Task<IEnumerable<FoodCategory>> GetBrachesCategoryAsync(int? BranchId = null, int? FoodCategoryId = null)
        {
            return await this.resRepos.GetBrachesCategoryAsync(BranchId, FoodCategoryId);
        }

        public async Task<IEnumerable<Discount>> GetBrachesDiscountsAsync(int? DiscountId = null, int? BranchId = null)
        {
            return await this.resRepos.GetBrachesDiscountsAsync(DiscountId, BranchId);
        }

        public async Task<IEnumerable<FoodSubCategory>> GetBrachesSubCategoryAsync(int? FoodCategoryId = null, int? FoodSubCategoryId = null)
        {
            return await this.resRepos.GetBrachesSubCategoryAsync(FoodCategoryId, FoodSubCategoryId);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.resRepos.GetByIdAsync(id);
        }

        public Task<Branch> GetBranchByMobileAsync(string mobile)
        {
            return this.resRepos.GetBranchByMobileAsync(mobile);
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
