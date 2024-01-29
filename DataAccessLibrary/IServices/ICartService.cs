using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ICartService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<Cart>> GetCartAsync(int? CustomerId = null, int? CartId = null, int? BranchId = null);
        Task<IEnumerable<CartItem>> GetCartItemAsync(int? CartItemId = null, int? CartId = null, int? FoodItemId = null);

    }
}
