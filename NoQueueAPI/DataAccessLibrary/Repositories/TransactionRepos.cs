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
    public class TransactionRepos<T> : ITransactionRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<Transaction> _enT;
        private readonly DbSet<BranchOrders> _enO;

        public TransactionRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enT= context.Set<Transaction>();
            _enO= context.Set<BranchOrders>();
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
       public async Task<IEnumerable<Transaction>> GetTransactionAsync(int? TransactionId = null, int? BranchId = null)
        {

            IQueryable<Transaction> query = _enT;
            query = query.Include(c => c.Customer);
            query = query.Include(c => c.Cart);

            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (TransactionId != null)
            {
                query = query.Where(x => x.TransactionId == TransactionId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<BranchOrders>> GetBranchOrdersAsync(int? OrderId=null,int? TransactionId = null, int? BranchId = null,int? CustomerId = null)
        {

            IQueryable<BranchOrders> query = _enO;
            query = query.Include(x => x.Transaction);
            query = query.Include(x => x.Customer);
            query = query.Include(x => x.Cart).ThenInclude(y=> y.CartItems.Where(ci => ci.IsDeleted == false)).ThenInclude(ci => ci.FoodItem);
            query = query.Include(x => x.Status);
            query=query.Include(x => x.Branch);
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (TransactionId != null)
            {
                query = query.Where(x => x.TransactionId == TransactionId);
            }
            if (OrderId != null)
            {
                query = query.Where(x => x.OrderId == OrderId);
            }
            if (CustomerId != null)
            {
                query = query.Where(x => x.CustomerId == CustomerId);
            }
            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedDate);
            return await query.ToListAsync();
        }
    }
}
