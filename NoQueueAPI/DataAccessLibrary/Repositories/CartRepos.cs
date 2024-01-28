using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class CartRepos<T> : ICartRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<Cart> _enC;
        private readonly DbSet<CartItem> _enCI;

        public CartRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enC = context.Set<Cart>();
            _enCI = context.Set<CartItem>();

        }
        public async void DeleteAsync(int id)
        {
            var companyMaster = await _entities.SingleOrDefaultAsync(x => x.Id == id);
            _entities.Remove(companyMaster);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await _entities.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void InsertAsync(T entity)
        {
            _entities.Add(entity);
        }

        public void UpdateAsync(T entity)
        {
            _entities.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public Task<Customer> GetByMobileAsync(string mobile)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cart>> GetCartAsync(int? CustomerId = null, int? CartId = null, int? BranchId = null)
        {
            IQueryable<Cart> query = _enC;
            query = query.Include(i => i.CartItems.Where(ci => ci.IsDeleted == false)).ThenInclude(ci => ci.FoodItem);


            if (CartId != null)
            {
                query = query.Where(x => x.CartId == CartId);
            }
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (CustomerId != null)
            {
                query = query.Where(x => x.CustomerId == CustomerId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<CartItem>> GetCartItemAsync(int? CartItemId = null, int? CartId = null, int? FoodItemId = null)
        {
            IQueryable<CartItem> query = _enCI;
            query = query.Include(ci => ci.FoodItem);
            if (CartId != null)
            {
                query = query.Where(x => x.CartId == CartId);
            }
            if (FoodItemId != null)
            {
                query = query.Where(x => x.FoodItemId == FoodItemId);
            }
            if (CartItemId != null)
            {
                query = query.Where(x => x.CartItemId == CartItemId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }

    }
}
