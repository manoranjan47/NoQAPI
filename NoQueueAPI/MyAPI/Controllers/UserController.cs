using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService<UserMaster> _userService;
        public UserController(
            IMapper mapper,
            IUserService<UserMaster> userService
        )
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserMasterDTO company)
        {
            var temp = _mapper.Map<UserMaster>(company);
            _userService.InsertAsync(temp);
            return Ok(await _userService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserMasterDTO user, int Id)
        {
            var data = await _userService.GetUserDataAsync(Id, user.Mobile, user.BranchId);
            var getUser = data.FirstOrDefault();
            if (getUser == null)
            {
                return NotFound(false);
            }
            _mapper.Map(user, getUser);
            getUser.ModifiedDate = DateTime.UtcNow;
            _userService.UpdateAsync(getUser);
            return Ok(await _userService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserMaster>>> GetAllUser(int? UserId = null, string? Mobile = null, int? BranchId = null)
        {

            return Ok(await _userService.GetUserDataAsync(UserId,Mobile,BranchId));
        }
    }
}
