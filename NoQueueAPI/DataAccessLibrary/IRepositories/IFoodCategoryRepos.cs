using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface IFoodCategoryRepos<T> : IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<FoodCategory>> GetBrachesCategoryAsync(int? BranchId = null, int? FoodCategoryId = null);
        Task<IEnumerable<FoodSubCategory>> GetBrachesSubCategoryAsync(int? FoodCategoryId = null, int? FoodSubCategoryId = null);
    }
}
