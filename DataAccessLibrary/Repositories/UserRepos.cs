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
    public class UserRepos<T> : IUserRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<BranchStaff> _enS;
        private readonly DbSet<UserMaster> _enU;

        public UserRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enS = context.Set<BranchStaff>();
            _enU=context.Set<UserMaster>();
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

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public Task<Customer> GetByMobileAsync(string mobile)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<UserMaster>> GetUserDataAsync(int? UserId = null,string? Mobile=null, int? BranchId = null)
        {

            IQueryable<UserMaster> query = _enU;
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (UserId != null)
            {
                query = query.Where(x => x.UserId == UserId);
            }
            if (Mobile != null)
            {
                query = query.Where(x => x.Mobile == Mobile);
            }
            return await query.ToListAsync();
        }
        public async Task<bool> UpdateBranchStaffAsync(BranchStaff branch)
        {
            var existingBranch = await _enS.FirstOrDefaultAsync(x => x.StaffId == branch.StaffId);

            if (existingBranch != null)
            {
                _enS.Update(branch);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
