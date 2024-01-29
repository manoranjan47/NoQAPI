namespace DataAccessLibrary
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void DeleteAsync(int id);
        void InsertAsync(T entity);
        void UpdateAsync(T entity);
        Task<bool> SaveChangesAsync();

    }
}
