using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares.Authentication;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService<Customer> _customerService;
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTProvider _jwtProvider;
        private readonly ISmsService _sms;
        private readonly ICartService<Cart> _cartService;


        public CustomerController(
            IMapper mapper,
            ICustomerService<Customer> customerService,
            IJWTProvider jwtProvider,
            UserManager<UserData> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserData> signInManager,
            ICartService<Cart> cartService,
            ISmsService sms
        )
        {
            _mapper = mapper;
            _customerService = customerService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider; 
            _sms = sms;
            _cartService = cartService;
        }

        [HttpPost]
        [Route("CustomerRegister")]
        public async Task<IActionResult> CustomerRegister([FromBody] CustomerLoginDTO company)//make company master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);

            var MasterCompany = await _customerService.GetByMobileAsync(company.Mobile);

            var temp = _mapper.Map<Customer>(company);

            if (MasterCompany != null && MasterCompany.IsRegisteredVerified == true)
            {
/*                return Conflict("User Already Registered");
*/            }
            else if (user == null)
            {
                string Role = "Customer";
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
                        _customerService.InsertAsync(temp);
                        await _customerService.SaveChangesAsync();
                    }
                }
            }
            else if (user != null && MasterCompany != null && MasterCompany.IsRegisteredVerified == false)
            {
                temp.LoginId = user.Id;
                _customerService.InsertAsync(temp);
                await _customerService.SaveChangesAsync();
            }


            var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);

            //var sms= _sms.SendSMS(company.Mobile, otp.ToString());
            return Ok(new { Message = "OTP sent successfully", OTP = otp });
        }
        
       /* [HttpPost]
        [Route("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin([FromBody] CustomerLoginDTO company)//make company master model for requir4d things only
        {
            var user = await _userManager.FindByNameAsync(company.Mobile);
            var MasterCompany = await _customerService.GetByMobileAsync(company.Mobile);
            var temp = _mapper.Map<Customer>(company);
            if (user == null)
            {
                return NotFound("please register");
            }
            else if (user != null && MasterCompany != null && MasterCompany.IsRegisteredVerified == true)
            {
                var otp = new Random().Next(100000, 999999).ToString(); // Generate OTP
                await _userManager.SetAuthenticationTokenAsync(user, "Default", "OTP", otp);
                //var sms= _sms.SendSMS(company.Mobile, otp.ToString());
                return Ok(new { Message = "OTP sent successfully", OTP = otp });
            }
            return BadRequest("Invalid request");
        }
*/
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
                    var customer = await _customerService.GetByMobileAsync(model.Mobile);

                    if (customer != null)
                    {
                        var carts = await _cartService.GetCartAsync(customer.CustomerId, null, customer.BranchId);
                        var cart = carts.FirstOrDefault();
                        if(cart == null) {
                            _cartService.InsertAsync(new Cart { BranchId=customer.BranchId,CustomerId=customer.CustomerId,IsDeleted=false});
                            await _cartService.SaveChangesAsync();
                        }
                        customer.IsRegisteredVerified = true;
                        _customerService.UpdateAsync(customer);
                        await _customerService.SaveChangesAsync();
                    }

                    user.Roles = "customer";
                    user.PhoneNumber = customer.Mobile;
                    string token = await _jwtProvider.GenerateTokenAsync(user);
                    user.token = token;
                    user.Roles = "Customer";
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


        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO company)
        {
            var temp = _mapper.Map<Customer>(company);
            _customerService.InsertAsync(temp);
            await _customerService.SaveChangesAsync();
            _cartService.InsertAsync(new Cart { BranchId = temp.BranchId, CustomerId = temp.CustomerId, IsDeleted = false });
            return Ok(await _cartService.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateBranch([FromBody] CustomerDTO company, int Id)
        {
            var temp = _mapper.Map<Customer>(company);
            temp.BranchId = Id;
            _customerService.UpdateAsync(temp);
            return Ok(await _customerService.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllBranches(int? CustomerId = null, string? Mobile = null, int? BranchId = null)
        {
            return Ok(await _customerService.GetCustomerAsync(CustomerId, Mobile, BranchId));
        }

       


    }
}
