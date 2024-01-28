using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface IRestaurantRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<Branch>> GetAllBrachesAsync(int? companyId=null, int? BranchId = null);
        Task<Branch> GetBranchByMobileAsync(string mobile);
        Task<IEnumerable<BankDetail>> GetAllBankDetailAsync(int? BankDetailId = null, int? BranchId = null);
        public Task<IEnumerable<FoodCategory>> GetBrachesCategoryAsync(int? BranchId = null, int? FoodCategoryId = null);
        Task<IEnumerable<FoodSubCategory>> GetBrachesSubCategoryAsync(int? FoodCategoryId = null, int? FoodSubCategoryId = null);
        Task<IEnumerable<Discount>> GetBrachesDiscountsAsync(int? DiscountId = null, int? BranchId = null);
        public Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync(int? FoodItemId = null, int? BranchId = null, int? FoodCategoryId = null, int? FoodSubCategoryId = null);
    }
}
