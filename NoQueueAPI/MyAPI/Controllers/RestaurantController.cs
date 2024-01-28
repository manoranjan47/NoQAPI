using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares.Authentication;
using System.ComponentModel.Design;
using Twilio.TwiML.Voice;


namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService<Branch> _branchService;
        private readonly IRestaurantService<BranchPhoto> _branchBranchPhoto;
        private readonly IRestaurantService<BankDetail> _bankService;

        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IMapper _mapper;
        private readonly IJWTProvider _jwtProvider;
        private readonly IFilesService _file;
        private readonly ISmsService _sms;

        public RestaurantController(
            IMapper mapper, 
            IRestaurantService<Branch> branchService, 
            IRestaurantService<BankDetail> bankService,
            IRestaurantService<BranchPhoto> branchBranchPhoto,
            UserManager<UserData> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserData> signInManager,
            IJWTProvider jwtProvider,
            IFilesService file,
            ISmsService sms
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _branchService = branchService;
            _bankService = bankService;
            _branchBranchPhoto = branchBranchPhoto;
            _file = file;
            _sms = sms;
            _jwtProvider = jwtProvider;

        }

        #region Auth
        [HttpPost]
        [Route("BranchRegister")]
        public async Task<IActionResult> BranchRegister([FromBody] BranchDTO branch)//make branch master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(branch.Mobile);
            var MasterBranch = await _branchService.GetBranchByMobileAsync(branch.Mobile);
            var temp = _mapper.Map<Branch>(branch);

            if (MasterBranch != null && MasterBranch.IsRegisteredVerified == true)
            {
                return Conflict("User Already Registered");
            }
            if (user == null)
            {
                string Role = "BranchAdmin";
                if (await _roleManager.RoleExistsAsync(Role))
                {
                    // User does not exist, register them
                    user = new UserData { UserName = branch.Mobile, Mobile = branch.Mobile, token = "" };
                    var result = await _userManager.CreateAsync(user);

                    if (!result.Succeeded)
                    {
                        return BadRequest("Registration failed");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Role);
                        temp.LoginId = user.Id;
                        _branchService.InsertAsync(temp);
                        await _branchService.SaveChangesAsync();

                        var branchData = await _branchService.GetBranchByMobileAsync(temp.Mobile);
                        if (branchData == null)
                        {
                            var branchAdd = new Branch();
                            branchAdd.BranchName = temp.BranchName;
                            branchAdd.BranchId = temp.BranchId;
                            branchAdd.Mobile = branch.Mobile;
                            _branchService.InsertAsync(branchAdd);
                        }
                        await _branchService.SaveChangesAsync();
                    }
                }
            }
            else if (user != null && MasterBranch != null && MasterBranch.IsRegisteredVerified == false)
            {
                temp.LoginId = user.Id;
                _branchService.InsertAsync(temp);
                await _branchService.SaveChangesAsync();
            }


            var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);

            // var sms= _sms.SendSMS(branch.Mobile, otp.ToString());
            return Ok(new { Message = "OTP sent successfully", OTP = otp });
        }

        [HttpPost]
        [Route("BranchLogin")]
        public async Task<IActionResult> BranchLogin([FromBody] BranchDTO branch)//make branch master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(branch.Mobile);
            var MasterBranch = await _branchService.GetBranchByMobileAsync(branch.Mobile);
            var temp = _mapper.Map<Branch>(branch);
            if (user == null)
            {
                return NotFound("please register");
            }
            else if (user != null && MasterBranch != null && MasterBranch.IsRegisteredVerified == true)
            {
                var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
                await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);
                //var sms= _sms.SendSMS(branch.Mobile, otp.ToString());
                return Ok(new { Message = "OTP sent successfully", OTP = otp,Route="branch" });
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
                    var MasterBranch = await _branchService.GetBranchByMobileAsync(model.Mobile);
                    if (MasterBranch != null)
                    {
                        MasterBranch.IsRegisteredVerified = true;
                        _branchService.UpdateAsync(MasterBranch);
                        await _branchService.SaveChangesAsync();
                    }
                    user.Roles = "branch";
                    user.PhoneNumber = MasterBranch.Mobile;
                    string token = await _jwtProvider.GenerateTokenAsync(user);
                    user.token = token;
                    user.Roles = "BranchAdmin";
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

        #endregion

        #region Branch
        [HttpPost]
        [Route("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchDTO branch)
        {
            var user = await _userManager.FindByNameAsync(branch.Mobile);
            if (user!=null)
            {
                return Conflict("This mobile is already associated with a user");
            }
            string Role = "BranchHead";
            if (await _roleManager.RoleExistsAsync(Role))
            {
                user = new UserData { UserName = branch.Mobile, Mobile = branch.Mobile, token = "" };
                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                   return BadRequest("Registration failed");
                }
                else
                {
                   await _userManager.AddToRoleAsync(user, Role);
                   var temp = _mapper.Map<Branch>(branch);
                    temp.LoginId = user.Id;
                    temp.IsRegisteredVerified=true;
                   _branchService.InsertAsync(temp);
                   return Ok(new { status = await _branchService.SaveChangesAsync(), data = temp });
                }
            }
            else
            {
                return Conflict("Role Not Found");

            }

        }

        [HttpPut]
        [Route("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchDTO updateBranch, int Id)
        {
            var branch = (await _branchService.GetAllBrachesAsync(null, updateBranch.BranchId)).FirstOrDefault();

            if (branch == null)
            {
                return NotFound(false);
            }

            var user = await _userManager.FindByIdAsync(branch.LoginId);

            if (user.UserName != updateBranch.Mobile)
            {
                var checkForNumberExist = await _userManager.FindByNameAsync(updateBranch.Mobile);

                if (checkForNumberExist != null)
                {
                    return Conflict("Number is already associated with some user");
                }

                // Update the username and mobile number
                user.UserName = updateBranch.Mobile;
                user.Mobile = updateBranch.Mobile;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return StatusCode(500, "Failed to update username and mobile number");
                }
            }

            _mapper.Map(updateBranch, branch);
            branch.ModifiedDate = DateTime.UtcNow;
            _branchService.UpdateAsync(branch);

            return Ok(await _branchService.SaveChangesAsync());
        }


        [HttpGet]
        [Route("GetAllBranch")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllBranches(int? CompanyId=null, int? BranchId = null)
        {
            return Ok(await _branchService.GetAllBrachesAsync(CompanyId,BranchId));
        }
        [HttpGet]
        [Route("GetBranchRoles")]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetBrancheRoles()
        {
            var excludedRoles = new[] { "Customer", "CompanyAdmin", "User","Branch Head" };

            var roles = await _roleManager.Roles
                .Where(x => !excludedRoles.Contains(x.Name)).ToListAsync(); // Assuming you are using EF Core
            return Ok(roles);
        }
        [HttpPost]
        [Route("AddBranchPhotos")]
        public async Task<IActionResult> AddBranchPhotos([FromBody] List<BranchPhotoDTO> company)
        {
            foreach (var item in company)
            {
                var temp = _mapper.Map<BranchPhoto>(item);
                temp.Photo = await _file.GetFilePath(item.Photo,"branch");
                temp.PhotoCategoryId = 1;
                _branchBranchPhoto.InsertAsync(temp);
            }
            return Ok(await _branchBranchPhoto.SaveChangesAsync());
        }

        [HttpPost]
        [Route("AddBranchBankDetail")]
        public async Task<IActionResult> AddBranchBankDetail([FromBody] BankDetailDTO company)
        {
            var temp = _mapper.Map<BankDetail>(company);
            _bankService.InsertAsync(temp);
            return Ok(await _bankService.SaveChangesAsync());
        }

        [HttpDelete]
        [Route("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch([FromBody] BranchDTO branch, int Id)
        {
            var data = await _branchService.GetAllBrachesAsync(null, branch.BranchId);
            var branchData = data.FirstOrDefault();
            if (branchData == null)
            {
                return NotFound(false);
            }
            branchData.IsRegisteredVerified = true;
            branchData.IsDeleted = true;
            branchData.ModifiedDate = DateTime.UtcNow;
            _branchService.UpdateAsync(branchData);
            return Ok(await _branchService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateBranchBankDetail")]
        public async Task<IActionResult> UpdateBranchBankDetail([FromBody] BankDetailDTO company, int Id)
        {
            var data = await _bankService.GetAllBankDetailAsync(Id, company.BranchId);

            var bank = data.FirstOrDefault();
            if (bank == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, bank);
            bank.ModifiedDate= DateTime.UtcNow;
            _bankService.UpdateAsync(bank);
            return Ok(await _bankService.SaveChangesAsync());
        }
      
        [HttpGet]
        [Route("GetAllBranchBankDetail")]
        public async Task<ActionResult<IEnumerable<BankDetail>>> GetAllBranchesBankDetail(int? BankDetailId = null, int? BranchId = null)
        {
            return Ok(await _branchService.GetAllBankDetailAsync(BankDetailId, BranchId));
        }
        [HttpDelete]
        [Route("DeleteBranchBankDetails")]
        public async Task<IActionResult> DeleteBranchBankDetails([FromBody] BankDetailDTO bank, int Id)
        {
            var data = await _bankService.GetAllBankDetailAsync(Id, bank.BranchId);
            var bankDetails = data.FirstOrDefault();
            if (bankDetails == null)
            {
                return NotFound(false);
            }
            bankDetails.IsDeleted = true;
            bankDetails.ModifiedDate = DateTime.UtcNow;
            _bankService.UpdateAsync(bankDetails);
            return Ok(await _bankService.SaveChangesAsync());
        }
        #endregion

   
       
    }
}
