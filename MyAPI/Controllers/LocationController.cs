using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocationService<CountryMaster> _countryService;
        private readonly ILocationService<StateMaster> _stateService;
        private readonly ILocationService<DistrictMaster> _districtService;
        private readonly ILocationService<CityMaster> _cityService;
        public LocationController(
           IMapper mapper,
           ILocationService<CountryMaster> countryService,
           ILocationService<StateMaster> stateService,
           ILocationService<DistrictMaster> districtService,
           ILocationService<CityMaster> cityService
       )
        {
            _mapper = mapper;
            _countryService = countryService;
            _stateService = stateService;
            _districtService = districtService;
            _cityService = cityService;
        }
        [HttpGet]
        [Route("GetAllCountry")]
        public async Task<ActionResult<IEnumerable<CountryMaster>>> GetAllCountry(int? CountryId = null)
        {
            return Ok(await _countryService.GetCountryAsync(CountryId));
        }

        [HttpGet]
        [Route("GetAllState")]
        public async Task<ActionResult<IEnumerable<StateMaster>>> GetAllStates(int? CountryId = null, int? StateId = null)
        {
            return Ok(await _stateService.GetStateAsync(CountryId, StateId ));
        }
        [HttpGet]
        [Route("GetAllDistrict")]
        public async Task<ActionResult<IEnumerable<DistrictMaster>>> GetAllDistrict(int? StateId = null, int? DistrictId = null)
        {
            return Ok(await _districtService.GetDistrictAsync(StateId,DistrictId));
        }
        [HttpGet]
        [Route("GetAllCity")]
        public async Task<ActionResult<IEnumerable<CityMaster>>> GetAllCity(int? DistrictId = null, int? CityId = null)
        {
            return Ok(await _cityService.GetCityAsync(DistrictId,CityId ));
        }
      /*  [HttpPost]
        [Route("AddCountry")]
        public async Task<IActionResult> AddCountry([FromBody] CountryMasterDTO country)
        {
            var temp = _mapper.Map<CountryMaster>(country);
            _countryService.InsertAsync(temp);
            return Ok(await _countryService.SaveChangesAsync());
        }
      


        [HttpPost]
        [Route("AddState")]
        public async Task<IActionResult> AddState([FromBody] StateMasterDTO state)
        {
            var temp = _mapper.Map<StateMaster>(state);
            _stateService.InsertAsync(temp);
            return Ok(await _stateService.SaveChangesAsync());
        }

        

        [HttpPost]
        [Route("AddDistrict")]
        public async Task<IActionResult> AddDistrict([FromBody] DistrictMasterDTO district)
        {
            var temp = _mapper.Map<DistrictMaster>(district);
            _districtService.InsertAsync(temp);
            return Ok(await _districtService.SaveChangesAsync());
        }
       
        [HttpPost]
        [Route("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] CityMasterDTO City)
        {
            var temp = _mapper.Map<CityMaster>(City);
            _cityService.InsertAsync(temp);
            return Ok(await _cityService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateDistrict")]
        public async Task<IActionResult> UpdateDistrict([FromBody] DistrictMasterDTO district, int Id)
        {
            var temp = _mapper.Map<DistrictMaster>(district);
            _districtService.UpdateAsync(temp);
            return Ok(await _stateService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryMasterDTO country, int Id)
        {
            var temp = _mapper.Map<CountryMaster>(country);
            _countryService.UpdateAsync(temp);
            return Ok(await _stateService.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateState")]
        public async Task<IActionResult> UpdateState([FromBody] StateMasterDTO state, int Id)
        {
            var temp = _mapper.Map<StateMaster>(state);
            _stateService.UpdateAsync(temp);
            return Ok(await _stateService.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] CityMasterDTO City, int Id)
        {
            var temp = _mapper.Map<CityMaster>(City);
            _cityService.UpdateAsync(temp);
            return Ok(await _stateService.SaveChangesAsync());
        }*/
    }
}
