using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares.Authentication;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageStaffController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IFilesService _file;
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTProvider _jwtProvider;
        private readonly ISmsService _sms;

        private readonly IManageStaffService<BranchStaff> _staffService;
        private readonly IRestaurantService<Branch> _branchService;

        public ManageStaffController(
            IMapper mapper,
            IManageStaffService<BranchStaff> staffService,
            IRestaurantService<Branch> branchService,
            IFilesService file,
            IJWTProvider jwtProvider,
            UserManager<UserData> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserData> signInManager,
            ISmsService sms
        )
        {
            _mapper = mapper;
            _staffService = staffService;
            _file = file;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
            _sms = sms;
            _roleManager = roleManager;
            _branchService = branchService;
        }


        [HttpPost]
        [Route("BranchStaffLogin")]
        public async Task<IActionResult> CustomerLogin([FromBody] BranchLoginDTO company)//make company master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);
            var MasterCompany = await _staffService.GetByMobileAsync(company.Mobile);
            if (user == null)
            {
                return NotFound("please register");
            }
            else if (user != null && MasterCompany != null && MasterCompany.IsRegisteredVerified == true)
            {
                var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
                await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);
                //var sms= _sms.SendSMS(company.Mobile, otp.ToString());
                return Ok(new { Message = "OTP sent successfully", OTP = otp, Route = "branch" });
            }
            return BadRequest("Invalid request");
        }

        [HttpPost("verify-phone")]
        public async Task<IActionResult> VerifyPhone([FromBody] VerifyPhoneRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Mobile);

            if (user != null)
            {
                var storedOtp = await _userManager.GetAuthenticationTokenAsync(user, "Default", "OTP");
                if (!string.IsNullOrEmpty(storedOtp) && storedOtp.Equals(model.OTP))
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", null);
                    var roles = await _userManager.GetRolesAsync(user);
                    switch (roles.FirstOrDefault())
                    {
                        case "Branch Head":
                            var branch = await _branchService.GetBranchByMobileAsync(model.Mobile);
                            if (branch != null)
                            {
                                branch.IsRegisteredVerified = true;
                                _branchService.UpdateAsync(branch);
                                await _branchService.SaveChangesAsync();
                            }
                            user.Roles = "branchhead";
                            user.PhoneNumber = branch.Mobile;
                            string token = await _jwtProvider.GenerateTokenAsync(user);
                            user.token = token;
                            user.Roles = "branchhead";
                            break;

                        default:
                            var MasterCompany = await _staffService.GetByMobileAsync(model.Mobile);
                            if (MasterCompany != null)
                            {
                                MasterCompany.IsRegisteredVerified = true;
                                _staffService.UpdateAsync(MasterCompany);
                                await _staffService.SaveChangesAsync();
                            }
                            user.Roles = "staff";
                            user.PhoneNumber = MasterCompany.Mobile;
                            string branch_token = await _jwtProvider.GenerateTokenAsync(user);
                            user.token = branch_token;
                            user.Roles = "staff";
                            break;
                    }

                    return Ok(new { Message = "User authenticated successfully", Token = user.token });
                }
                return BadRequest("Invalid OTP. Please try again.");
            }

            return NotFound("User not found");
        }

        [HttpPost("regenerate-otp")]
        public async Task<IActionResult> RegenerateOTP([FromBody] RegenerateOTPRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Mobile);

            if (user != null)
            {
                var otp = new Random().Next(100000, 999999).ToString(); // Generate new OTP
                await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);

                // Send the new OTP to the user (using Twilio, Nexmo, etc.)

                return Ok(new { Message = "New OTP sent successfully", otp = otp });
            }

            return NotFound("User not found");
        }
        /*[HttpPost]
        [Route("BranchStaffRegister")]
        public async Task<IActionResult> CustomerRegister([FromBody] StaffLoginDTO company)
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);
            var MasterCompany = await _staffService.GetByMobileAsync(company.Mobile);

            var temp = _mapper.Map<BranchStaff>(company);

            if (MasterCompany != null && MasterCompany.IsRegisteredVerified == true)
            {
                return Conflict("User Already Registered");
            }
            if (user == null)
            {
                string Role = "Staff";
                if (await _roleManager.RoleExistsAsync(Role))
                {
                    // User does not exist, register them
                    user = new UserData { UserName = company.Mobile, Mobile = company.Mobile, token = "" };
                    var result = await _userManager.CreateAsync(user);

                    if (!result.Succeeded)
                    {
                        return BadRequest("Registration failed");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Role);
                        temp.LoginId = user.Id;
                        _staffService.InsertAsync(temp);
                        await _staffService.SaveChangesAsync();
                    }
                }
            }
            else if (user != null && MasterCompany != null && MasterCompany.IsRegisteredVerified == false)
            {
                temp.LoginId = user.Id;
                _staffService.InsertAsync(temp);
                await _staffService.SaveChangesAsync();
            }


            var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);

            //var sms= _sms.SendSMS(company.Mobile, otp.ToString());
            return Ok(new { Message = "OTP sent successfully", OTP = otp });
        }


*/

        [HttpPost]
        [Route("AddStaff")]
        public async Task<IActionResult> AddStaff([FromBody] BranchStaffDTO company)
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);
            var currentStaff = await _staffService.GetByMobileAsync(company.Mobile);

            if (user != null && currentStaff != null)
            {
                return Conflict("Number used is already associated with other user.");
            }
            var role = await _roleManager.FindByIdAsync(company.RoleId);
            if (role != null)
            {
                user = new UserData { UserName = company.Mobile, Mobile = company.Mobile, token = "" };
                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest("Registration failed");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, role.NormalizedName);
                    var temp = _mapper.Map<BranchStaff>(company);
                    temp.PhotoUrl = await _file.GetFilePath(temp.PhotoUrl, "staff");
                    temp.LoginId = user.Id;
                    temp.IsVerified = true;
                    temp.IsRegisteredVerified = true;
                    temp.NormalizedName = role.NormalizedName;
                    _staffService.InsertAsync(temp);
                   return Ok(await _staffService.SaveChangesAsync());
                }
            }
            return NoContent();
        }



        /* [HttpPost]
         [Route("AddStaff")]
         public async Task<IActionResult> AddStaff([FromBody] BranchStaffDTO company)
         {
             var temp = _mapper.Map<BranchStaff>(company);
             temp.PhotoUrl = await _file.GetFilePath(temp.PhotoUrl,"staff");
             _staffService.InsertAsync(temp);
             return Ok(await _staffService.SaveChangesAsync());
         }*/

        [HttpPut]
        [Route("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff([FromBody] BranchStaffDTO staff, int Id)
        {
            var data = await _staffService.GetBranchStaffAsync(Id, staff.BranchId, staff.CompanyId);
            var staffGet = data.FirstOrDefault();
            if (staffGet == null)
            {
                return NotFound(false);
            }
            _mapper.Map(staff, staffGet);
            staffGet.ModifiedDate = DateTime.UtcNow;
            staffGet.PhotoUrl = await _file.GetFilePath(staffGet.PhotoUrl, "staff");
            _staffService.UpdateAsync(staffGet);
            return Ok(await _staffService.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetAllStaff")]
        public async Task<ActionResult<IEnumerable<BranchStaff>>> GetAllStaff(int? StaffId = null, int? BranchId = null, int? CompanyId = null)
        {
            return Ok(await _staffService.GetBranchStaffAsync(StaffId, BranchId, CompanyId));
        }

        [HttpDelete]
        [Route("DeleteStaff")]
        public async Task<IActionResult> DeleteBranchStaffItem([FromBody] BranchStaffDTO staff, int Id)
        {
            var data = await _staffService.GetBranchStaffAsync(Id, staff.BranchId, staff.CompanyId);
            var staffGet = data.FirstOrDefault();
            if (staffGet == null)
            {
                return NotFound(false);
            }
            staffGet.IsDeleted = true;
            staffGet.ModifiedDate = DateTime.UtcNow;
            _staffService.UpdateAsync(staffGet);
            return Ok(await _staffService.SaveChangesAsync());
        }



    }
}
