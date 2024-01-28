using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class ManageStaffRepos<T> : IManageStaffRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<BranchStaff> _enS;

        public ManageStaffRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enS = context.Set<BranchStaff>();

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
        public async Task<IEnumerable<BranchStaff>> GetBranchStaffAsync(int? StaffId=null, int? BranchId = null,int? CompanyId = null)
        {

            IQueryable<BranchStaff> query = _enS;
            query.Include(x => x.Role);
            if (StaffId != null)
            {
                query = query.Where(x => x.StaffId == StaffId);
            }
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (CompanyId != null)
            {
                query = query.Where(x => x.CompanyId == CompanyId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<BranchStaff> GetByMobileAsync(string mobile)
        {
            return await _entities
                .OfType<BranchStaff>()
                .Where(s => s.Mobile == mobile && s.IsVerified==true)
                .OrderByDescending(s => s.CreatedDate)
                .FirstOrDefaultAsync();
        }
    }
}
