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
    public class FoodCategoryRepos<T> : IFoodCategoryRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<FoodCategory> _enC;
        private readonly DbSet<FoodSubCategory> _enSC;
        public FoodCategoryRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enC = context.Set<FoodCategory>();
            _enSC = context.Set<FoodSubCategory>();

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
        public async Task<IEnumerable<FoodCategory>> GetBrachesCategoryAsync( int? BranchId = null,int? FoodCategoryId= null)
        {

            IQueryable<FoodCategory> query = _enC;
            query = query.Include(foodCategory => foodCategory.FoodSubCategories);

            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (FoodCategoryId != null)
            {
                query = query.Where(x => x.FoodCategoryId == FoodCategoryId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<FoodSubCategory>> GetBrachesSubCategoryAsync(int? FoodCategoryId = null, int? FoodSubCategoryId = null)
        {

            IQueryable<FoodSubCategory> query = _enSC;
            if (FoodCategoryId != null)
            {
                query = query.Where(x => x.FoodCategoryId == FoodCategoryId);
            }
            if (FoodSubCategoryId != null)
            {
                query = query.Where(x => x.FoodSubCategoryId == FoodSubCategoryId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
       
    }
}
