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
    public class CartService<T> : ICartService<T> where T : BaseEntity
    {
        private readonly ICartRepos<T> resRepos;

        public CartService(ICartRepos<T> resRepos)
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

        public async Task<IEnumerable<Cart>> GetCartAsync(int? CustomerId = null, int? CartId = null, int? BranchId = null)
        {
            return await this.resRepos.GetCartAsync(CustomerId, CartId, BranchId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemAsync(int? CartItemId = null, int? CartId = null, int? FoodItemId = null)
        {
            return await this.resRepos.GetCartItemAsync(CartItemId, CartId, FoodItemId);
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
