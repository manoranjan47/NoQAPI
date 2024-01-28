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
    public class RestaurantRepository<T> : IRestaurantRepository<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<Branch> _en;
        private readonly DbSet<FoodCategory> _enC;
        private readonly DbSet<FoodSubCategory> _enSC;
        private readonly DbSet<BankDetail> _enBD;
        private readonly DbSet<Discount> _enD;

        private readonly DbSet<FoodItem> _enF;
        public RestaurantRepository(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _en = context.Set<Branch>();
            _enC = context.Set<FoodCategory>();
            _enF=context.Set<FoodItem>();
            _enSC = context.Set<FoodSubCategory>();
            _enBD= context.Set<BankDetail>();
            _enD= context.Set<Discount>();

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
       
        public async Task<IEnumerable<Branch>> GetAllBrachesAsync(int? companyId = null, int? BranchId = null)
        {

            IQueryable<Branch> query = _en;
            query = query.Include(x => x.BankDetails).Where(x=>x.IsActive==true);
            query = query.Include(x => x.BranchPhotos).Where(x => x.IsActive == true);

            if (companyId != null)
            {
                query = query.Where(x => x.CompanyId == companyId);
            }
            if(BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();

        }
        public async Task<IEnumerable<BankDetail>> GetAllBankDetailAsync(int? BankDetailId = null, int? BranchId = null)
        {

            IQueryable<BankDetail> query = _enBD;

            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (BranchId != null)
            {
                query = query.Where(x => x.BankDetailId == BankDetailId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();

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
        public async Task<IEnumerable<Discount>> GetBrachesDiscountsAsync(int? DiscountId = null, int? BranchId = null)
        {

            IQueryable<Discount> query = _enD;
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
            if (DiscountId!= null)
            {
                query = query.Where(x => x.DiscountId == DiscountId);
            }
            query = query.Where(x => x.IsDeleted == false);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync(int? FoodItemId = null, int? BranchId = null, int? FoodCategoryId = null, int? FoodSubCategoryId = null)
        {
            IQueryable<FoodItem> query = _enF;
            query = query.Include(foodCategory => foodCategory.FoodCategory);
            query = query.Include(foodCategory => foodCategory.FoodSubCategory);

            if (FoodItemId != null)
            {
                query = query.Where(x => x.FoodItemId == FoodItemId);
            }
            if (BranchId != null)
            {
                query = query.Where(x => x.BranchId == BranchId);
            }
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

        public async Task<Branch> GetBranchByMobileAsync(string mobile)
        {
            return await _entities
               .OfType<Branch>()
               .Where(s => s.Mobile == mobile)
               .OrderByDescending(s => s.CreatedDate)
               .FirstOrDefaultAsync();
        }
    }
}
