using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Repositories;


namespace DataAccessLibrary.Services
{
    public class CompanyService<T> : ICompanyService<T> where T : BaseEntity
    {
        private readonly ICompanyRepos<T> companyRepos;

        public CompanyService(ICompanyRepos<T> companyRepos)
        {
            this.companyRepos = companyRepos;
        }

        public void DeleteAsync(int id)
        {
            this.companyRepos.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.companyRepos.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.companyRepos.GetByIdAsync(id);
        }

        public void InsertAsync(T entity)
        {
            this.companyRepos.InsertAsync(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.companyRepos.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            this.companyRepos.UpdateAsync(entity);
        }
    }
}
