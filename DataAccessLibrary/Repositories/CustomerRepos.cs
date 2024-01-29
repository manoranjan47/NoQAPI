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
    public class CustomerRepos<T> : ICustomerRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<Customer> _enC;

        public CustomerRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enC = context.Set<Customer>();
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

        public async Task<Customer> GetByMobileAsync(string mobile)
        {
            return await _entities
                .OfType<Customer>()
                .Include(c => c.Carts)  // Include the Carts relationship
                .Where(s => s.Mobile == mobile)
                .OrderByDescending(s => s.CreatedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync(int? CustomerId = null, string? Mobile = null, int? BranchId = null)
        {

            IQueryable<Customer> query = _enC;
            query = query.Include(cart => cart.Carts);

            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (CustomerId != null)
            {
                query = query.Where(x => x.CustomerId == CustomerId);
            }
            if (Mobile != null)
            {
                query = query.Where(x => x.Mobile == Mobile);
            }

            return await query.ToListAsync();
        }
       
    }
}
