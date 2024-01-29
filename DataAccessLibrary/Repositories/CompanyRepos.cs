using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLibrary.Repositories
{
    public class CompanyRepos<T> : ICompanyRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<CompanyMaster> _enC;
        public CompanyRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enC = context.Set<CompanyMaster>();
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

        public  void InsertAsync(T entity)
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

        public async Task<IEnumerable<CompanyMaster>> GetAllCompanyAsync(int? CompanyId = null, int? CategoryId = null,string? Mobile=null, int? Id = null)
        {

            IQueryable<CompanyMaster> query = _enC;
            if (CompanyId != null)
            {
                query = query.Where(x => x.CompanyId == CompanyId);
            }
            if (CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == CategoryId);
            }
            if (Id != null)
            {
                query = query.Where(x => x.Id == Id);
            }
            if (Mobile != null)
            {
                query = query.Where(x => x.Mobile== Mobile);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<CompanyMaster> GetByMobileAsync(string mobile)
        {
            return await _entities
                .OfType<CompanyMaster>()
                .Where(s => s.Mobile == mobile)
                .OrderByDescending(s => s.CreatedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<Branch> GetBranchByMobileAsync(string mobile)
        {
            return await _entities
              .OfType<Branch>()
              .Where(s => s.Mobile == mobile && s.IsRegisteredVerified==true)
              .OrderByDescending(s => s.CreatedDate)
              .FirstOrDefaultAsync();
        }
    }
}
