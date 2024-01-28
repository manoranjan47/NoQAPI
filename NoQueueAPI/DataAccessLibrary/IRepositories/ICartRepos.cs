using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ICartRepos<T> : IRepository<T> where T : BaseEntity
    {
        //additional functions to be defined here
        Task<IEnumerable<Cart>> GetCartAsync(int? CustomerId = null, int? CartId = null, int? BranchId = null);
        Task<IEnumerable<CartItem>> GetCartItemAsync(int? CartItemId = null, int? CartId = null, int? FoodItemId = null);
    }
}
