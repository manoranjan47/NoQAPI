using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLibrary.Repositories
{
    public class CompanyRepos<T> : ICompanyRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        public CompanyRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
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

    }
}
