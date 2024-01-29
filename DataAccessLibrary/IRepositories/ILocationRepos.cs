using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ILocationRepos<T> : IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<CountryMaster>> GetCountryAsync(int? CountryId = null);
        Task<IEnumerable<StateMaster>> GetStateAsync(int? CountryId = null, int? StateId = null);
        Task<IEnumerable<DistrictMaster>> GetDistrictAsync(int? StateId = null, int? DistrictId = null);
        Task<IEnumerable<CityMaster>> GetCityAsync(int? DistrictId = null, int? CityId = null);
    }
}
