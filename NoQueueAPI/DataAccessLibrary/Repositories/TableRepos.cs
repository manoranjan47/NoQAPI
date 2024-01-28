using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class TableRepos<T> : ITableRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<BranchTables> _enT;

        public TableRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enT = context.Set<BranchTables>();
        }
        public async void DeleteAsync(int id)
        {
            var userMaster = await _entities.SingleOrDefaultAsync(x => x.Id == id);
            _entities.Remove(userMaster);
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
        public async Task<bool> UpdateBranchTableAsync(BranchTables branch)
        {
            var existingBranch = await _enT.FirstOrDefaultAsync(x => x.TableId == branch.TableId);

            if (existingBranch != null)
            {
                _enT.Update(branch);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
        public async Task<IEnumerable<BranchTables>> GetBranchTablesAsync(int? TableId = null, int? BranchId = null, bool? TakeAway = null)
        {

            IQueryable<BranchTables> query = _enT;
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (TableId != null)
            {
                query = query.Where(x => x.TableId == TableId);
            }
            if (TakeAway != null)
            {
                query = query.Where(x => x.IsTakeAway == TakeAway);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
    }
}
