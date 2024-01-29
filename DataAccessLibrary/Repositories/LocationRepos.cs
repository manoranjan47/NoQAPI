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
    public class LocationRepos<T> : ILocationRepos<T> where T : BaseEntity
    {
        private readonly NoQContext _context;
        private readonly DbSet<T> _entities;
        private readonly DbSet<CountryMaster> _enCo;
        private readonly DbSet<StateMaster> _enS;
        private readonly DbSet<CityMaster> _enCy;
        private readonly DbSet<DistrictMaster> _enD;
        public LocationRepos(NoQContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
            _enCo = context.Set<CountryMaster>();
            _enS = context.Set<StateMaster>();
            _enCy= context.Set<CityMaster>();
            _enD = context.Set<DistrictMaster>();
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
        public async Task<IEnumerable<CountryMaster>> GetCountryAsync(int? CountryId = null)
        {
            IQueryable<CountryMaster> query = _enCo;
            query = query.Include(x => x.StateMasters);
            if (CountryId != null)
            {
                query = query.Where(x => x.CountryId == CountryId);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<StateMaster>> GetStateAsync(int? CountryId = null, int? StateId = null)
        {
            IQueryable<StateMaster> query = _enS;
            if (CountryId != null)
            {
                query = query.Where(x => x.CountryId == CountryId);
            }
            if (StateId != null)
            {
                query = query.Where(x => x.StateId == StateId);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<DistrictMaster>> GetDistrictAsync( int? StateId = null,int? DistrictId = null)
        {
            IQueryable<DistrictMaster> query = _enD;
            if (DistrictId != null)
            {
                query = query.Where(x => x.DistrictId == DistrictId);
            }
            if (StateId != null)
            {
                query = query.Where(x => x.StateId == StateId);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<CityMaster>> GetCityAsync(int? DistrictId = null, int? CityId = null)
        {
            IQueryable<CityMaster> query = _enCy;
            if (DistrictId != null)
            {
                query = query.Where(x => x.DistrictId == DistrictId);
            }
            if (CityId != null)
            {
                query = query.Where(x => x.CityId == CityId);
            }
            return await query.ToListAsync();
        }
    }
}
