using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ApplicationDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            return entities.ToListAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return entities.SingleOrDefaultAsync(item => item.Id == id);
        }


        public void InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
