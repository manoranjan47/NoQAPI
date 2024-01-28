using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace DataAccessLibrary.Repositories
{
    public class DiscountRepos<T> : IDiscountRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<Discount> _enD;

        private readonly DbSet<FoodItem> _enF;
        public DiscountRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enD= context.Set<Discount>();

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
       public async Task<IEnumerable<Discount>> GetBrachesDiscountsAsync(int? DiscountId = null, int? BranchId = null)
        {

            IQueryable<Discount> query = _enD;
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (DiscountId!= null)
            {
                query = query.Where(x => x.DiscountId == DiscountId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
    }
}
