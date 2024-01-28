using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface IFoodCategoryService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<FoodCategory>> GetBrachesCategoryAsync(int? BranchId = null, int? FoodCategoryId = null);
        Task<IEnumerable<FoodSubCategory>> GetBrachesSubCategoryAsync(int? FoodCategoryId = null, int? FoodSubCategoryId = null);
    }
}
