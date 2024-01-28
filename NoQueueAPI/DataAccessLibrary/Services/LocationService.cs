using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class LocationService<T> : ILocationService<T> where T : BaseEntity
    {
        private readonly ILocationRepos<T> resRepos;

        public LocationService(ILocationRepos<T> resRepos)
        {
            this.resRepos = resRepos;
        }

        public void DeleteAsync(int id)
        {
            this.resRepos.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.resRepos.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllCategoryAsync()
        {
            return await this.resRepos.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.resRepos.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CountryMaster>> GetCountryAsync(int? CountryId = null)
        {
            return await this.resRepos.GetCountryAsync(CountryId);
        }

        public async Task<IEnumerable<StateMaster>> GetStateAsync(int? CountryId = null, int? StateId = null)
        {
            return await this.resRepos.GetStateAsync(CountryId, StateId);
        }
        public async Task<IEnumerable<DistrictMaster>> GetDistrictAsync(int? StateId = null, int? DistrictId = null)
        {
            return await this.resRepos.GetDistrictAsync(StateId, DistrictId);
        }
        public async Task<IEnumerable<CityMaster>> GetCityAsync(int? DistrictId = null, int? CityId = null)
        {
            return await this.resRepos.GetCityAsync(DistrictId, CityId);
        }

      

      

        public void InsertAsync(T entity)
        {
            this.resRepos.InsertAsync(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.resRepos.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            this.resRepos.UpdateAsync(entity);
        }
    }
}
