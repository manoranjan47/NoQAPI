using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ILocationService<T> : IService<T> where T : BaseEntity
    {
        public Task<IEnumerable<CountryMaster>> GetCountryAsync(int? CountryId = null);
        public Task<IEnumerable<StateMaster>> GetStateAsync(int? CountryId = null, int? StateId = null);
        public Task<IEnumerable<DistrictMaster>> GetDistrictAsync(int? StateId = null, int? DistrictId = null);
        public Task<IEnumerable<CityMaster>> GetCityAsync(int? DistrictId = null, int? CityId = null);
    }
}
