using AutoMapper;
using DataAccessLibrary;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares.Authentication;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //private readonly IService<CompanyMaster> _companyService;
        private readonly IMapper _mapper;
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISmsService _sms;
        private readonly IJWTProvider _jwtProvider;

        private readonly ICompanyService<CompanyMaster> _companyService;
        private readonly ICompanyService<CategoryMaster> _categoryService;
        private readonly IRestaurantService<Branch> _branchService;


        public CompanyController(
            IJWTProvider jwtProvider,
            ICompanyService<CompanyMaster> service,
            IMapper mapper, 
            ICompanyService<CategoryMaster> categoryService,
            UserManager<UserData> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserData> signInManager,
            ISmsService sms,
            IRestaurantService<Branch> branchService)
        {
            this._companyService = service;
            _mapper = mapper;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _sms = sms;
            _roleManager = roleManager;
            _jwtProvider = jwtProvider;
            _branchService = branchService;
        }

        #region Auths

        [HttpPost]
        [Route("CompanyRegister")]
        public async Task<IActionResult> CompanyRegister([FromBody] CompanyMasterDTO company)//make company master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);
            var MasterCompany = await _companyService.GetByMobileAsync(company.Mobile);
            var temp = _mapper.Map<CompanyMaster>(company);

            if (user!=null && MasterCompany != null && MasterCompany.IsRegisteredVerified == true)
            {
                return Conflict("User Already Registered");
            }
            if (user == null)
            {
                string Role = "CompanyAdmin";
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
                        _companyService.InsertAsync(temp);
                        await _companyService.SaveChangesAsync();
                        var branch = new Branch();
                        branch.LoginId = user.Id;
                        branch.BranchName = "Branch 1";
                        branch.CompanyId = temp.CompanyId;
                        branch.Mobile = company.Mobile;
                        branch.IsPrimary = true;
                        _branchService.InsertAsync(branch);
                        await _branchService.SaveChangesAsync();
                    }
                }
                else
                {
                    return Conflict("Role Not Found");
                }
            }
            else if (user != null && MasterCompany != null && MasterCompany.IsRegisteredVerified == false)
            {
               
                temp.LoginId = user.Id;
                _companyService.InsertAsync(temp);
                await _companyService.SaveChangesAsync();
                var branchData = await _branchService.GetBranchByMobileAsync(temp.Mobile);
                branchData.IsRegisteredVerified = false;
                branchData.CompanyId = temp.CompanyId;
                _branchService.UpdateAsync(branchData);
                await _branchService.SaveChangesAsync();

            }


            var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);

           // var sms= _sms.SendSMS(company.Mobile, otp.ToString());
            return Ok(new { Message = "OTP sent successfully", OTP = otp });
        }
        
        [HttpPost]
        [Route("CompanyLogin")]
        public async Task<IActionResult> CompanyLogin([FromBody] CompanyMasterDTO company)
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);

            if (user == null)
            {
                return NotFound("Please register.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var route = "";

            switch (roles.FirstOrDefault())
            {
                case "Branch Head":
                    var branch = await _branchService.GetBranchByMobileAsync(company.Mobile);
                    if (branch?.IsRegisteredVerified == true)
                    {
                        route = "branch";
                    }
                    break;

                case "CompanyAdmin":
                    var companyData = await _companyService.GetByMobileAsync(company.Mobile);
                    if (companyData?.IsRegisteredVerified == true)
                    {
                        route = "company";
                    }
                    break;
            }

            var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);
            // var sms = _sms.SendSMS(company.Mobile, otp.ToString());

            return Ok(new { Message = "OTP sent successfully", OTP = otp, Route = route });
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
                    var MasterCompany = await _companyService.GetByMobileAsync(model.Mobile);
                    var branchData = await _branchService.GetBranchByMobileAsync(model.Mobile);
                    branchData.LoginId = user.Id;
                    branchData.IsRegisteredVerified = true;
                  
                    if (MasterCompany != null)
                    {
                        MasterCompany.IsRegisteredVerified = true;
                        _companyService.UpdateAsync(MasterCompany);
                        await _companyService.SaveChangesAsync();
                        _branchService.UpdateAsync(branchData);
                        await _branchService.SaveChangesAsync();
                    }
                    user.Roles = "company";
                    user.PhoneNumber = MasterCompany.Mobile;
                    string token = await _jwtProvider.GenerateTokenAsync(user);
                    user.token = token;
                    user.Roles = "CompanyAdmin";
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

        #region Company Controllers

        [HttpPost]
        [Route("AddCompanyCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryMasterDTO category)//make company master model for requir4d things only
        {
            var temp = _mapper.Map<CategoryMaster>(category);
            _categoryService.InsertAsync(temp);
            return Ok(await _companyService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllCompanyCategory")]
        public async Task<ActionResult<IEnumerable<CategoryMaster>>> GetAllCompanyCategory()
        {
            return Ok(await _categoryService.GetAllAsync());
        }


        [HttpGet]
        [Route("GetCompany/{mobile}")]
        public async Task<ActionResult<CompanyMaster>> GetCompanyByMobile(string mobile)
        {
            return Ok(await _companyService.GetByMobileAsync(mobile));
        }

      
        [HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> AddCompany([FromBody] CompanyMasterDTO company)//make company master model for requir4d things only
        {
            var temp = _mapper.Map<CompanyMaster>(company);
            temp.StatusUpdatedDate = DateTime.UtcNow;
            _companyService.InsertAsync(temp);
            return Ok(await _companyService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDTO company, int Id)
        {
            var data = await _companyService.GetAllCompanyAsync(Id, company.CategoryId, company.Mobile, null);
            var companyData = data.FirstOrDefault();
            if (companyData == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, companyData);
            companyData.ModifiedDate = DateTime.UtcNow;
            companyData.StatusUpdatedDate = DateTime.UtcNow;
            _companyService.UpdateAsync(companyData);
            return Ok(await _companyService.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetAllCompanies")]
        public async Task<ActionResult<IEnumerable<CompanyMaster>>> GetAllCompanies(int? CompanyId = null, int? BranchId = null, string? Mobile = null, int? Id = null)
        {
            return Ok(await _categoryService.GetAllCompanyAsync(CompanyId, BranchId, Mobile, Id));
        }

        [HttpGet]
        [Route("GetCompany/{id}")]
        public async Task<ActionResult<Customer>> GetCompany(int id)
        {
            return Ok(await _companyService.GetByIdAsync(id));
        }

        #endregion


    }
}
