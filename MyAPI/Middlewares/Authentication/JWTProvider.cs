using DataAccessLibrary.Enum;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace MyAPI.Middlewares.Authentication
{
    public sealed class JWTProvider : IJWTProvider
    {
        private readonly JWTOptions _options;
        private readonly ICompanyService<CompanyMaster> _companyService;
        private readonly ICustomerService<Customer> _customerService;
        private readonly IManageStaffService<BranchStaff> _staffService;
        private readonly IRestaurantService<Branch> _branchService;
        public JWTProvider(IOptions<JWTOptions> options,IRestaurantService<Branch> branchService,
        ICompanyService<CompanyMaster> companyService, IManageStaffService<BranchStaff> staffService, ICustomerService<Customer> customerService)
        {
            _options = options.Value;
            _companyService = companyService;
            _customerService = customerService;
            _staffService = staffService;
            _branchService = branchService;
        }
        public async Task<string> GenerateTokenAsync(UserData userData)
        {
           
            var claims = new List<Claim> { 
               // new(JwtRegisteredClaimNames.Email, userData.Email),
                new(JwtRegisteredClaimNames.Sub,userData.Id.ToString()),
                new Claim(ClaimTypes.Name, userData.UserName),
                //new Claim(ClaimTypes.Role, userData.RoleId.ToString())
            };
            if (userData.Roles == "customer")
            {
                var MasterCustomer = await _customerService.GetByMobileAsync(userData.PhoneNumber);
                claims?.Add(new Claim("Id", MasterCustomer.CustomerId.ToString()));
                claims?.Add(new Claim(ClaimTypes.Role, userData.Roles.ToString()));
                claims?.Add(new Claim("Role", userData.Roles.ToString()));
                claims?.Add(new Claim("Name", MasterCustomer.Name.ToString()));
                claims?.Add(new Claim("Mobile", MasterCustomer.Mobile.ToString()));
                claims?.Add(new Claim("LoginId", MasterCustomer.LoginId.ToString()));
                claims?.Add(new Claim("CartId", MasterCustomer.Carts.FirstOrDefault().CartId.ToString()));

            }
            if (userData.Roles == "staff")
            {
                var MasterCompany = await _staffService.GetByMobileAsync(userData.PhoneNumber);
                claims?.Add(new Claim("Id", MasterCompany.StaffId.ToString()));
                claims?.Add(new Claim("CompanyId", MasterCompany.CompanyId.ToString()));
                claims?.Add(new Claim("BranchId", MasterCompany.BranchId.ToString()));
                claims?.Add(new Claim("Mobile", MasterCompany.Mobile !=null ?MasterCompany.Mobile.ToString():""));
                claims?.Add(new Claim("LoginId", MasterCompany.LoginId.ToString()));
                claims?.Add(new Claim("ContactPerson", MasterCompany.Name != null ? MasterCompany.Name.ToString() : ""));
                claims?.Add(new Claim("Role", MasterCompany.NormalizedName.ToString()));
                claims?.Add(new Claim(ClaimTypes.Role, userData.Roles.ToString()));

            }
            if (userData.Roles == "company")
            {
                var MasterCompany = await _companyService.GetByMobileAsync(userData.PhoneNumber);
                claims?.Add(new Claim("Id", MasterCompany.CompanyId.ToString()));
                claims?.Add(new Claim("CompanyId", MasterCompany.CompanyId.ToString()));
                claims?.Add(new Claim("CompanyName", MasterCompany.CompanyName.ToString()));
                claims?.Add(new Claim("Mobile", MasterCompany.Mobile.ToString()));
                claims?.Add(new Claim("LoginId", MasterCompany.LoginId.ToString()));
                claims?.Add(new Claim("ContactPerson", MasterCompany.ContactPerson !=null ? MasterCompany.ContactPerson.ToString() : ""));
                claims?.Add(new Claim("Role", userData.Roles.ToString()));
                claims?.Add(new Claim(ClaimTypes.Role, userData.Roles.ToString()));

            }
            if (userData.Roles == "branchhead")
            {
                var MasterCompany = await _branchService.GetBranchByMobileAsync(userData.PhoneNumber);
                claims?.Add(new Claim("Id", MasterCompany.BranchId.ToString()));
                claims?.Add(new Claim("BranchId", MasterCompany.BranchId.ToString()));
                claims?.Add(new Claim("BranchName", MasterCompany.BranchName.ToString()));
                claims?.Add(new Claim("CompanyId", MasterCompany.CompanyId.ToString()));
                claims?.Add(new Claim("Mobile", MasterCompany.Mobile.ToString()));
                claims?.Add(new Claim("LoginId", MasterCompany.LoginId.ToString()));
                claims?.Add(new Claim("ContactPerson", MasterCompany.ContactPerson != null ? MasterCompany.ContactPerson.ToString() : ""));
                claims?.Add(new Claim("Role", "BranchAdmin"));
                claims?.Add(new Claim(ClaimTypes.Role, userData.Roles.ToString()));

            }
            /*            claims?.Add(new Claim(ClaimTypes.Role, userData.Roles.ToString()));
            */
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                    SecurityAlgorithms.HmacSha256
                );

            var token= new JwtSecurityToken(
                    _options.Issuer,
                    _options.Audience,
                    claims,
                    null,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials);

            string tokenValue=new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }

    }
}
