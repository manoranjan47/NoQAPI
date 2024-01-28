using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface IFoodItemsService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync(int? FoodItemId = null, int? BranchId = null, int? FoodCategoryId = null, int? FoodSubCategoryId = null, bool? IsNonVeg = null);
    }
}
