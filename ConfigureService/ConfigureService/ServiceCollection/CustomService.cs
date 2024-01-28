using DataAccessLibrary;
using DataAccessLibrary.Models;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class CustomService : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ILogin, LoginRepos>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IPaymentTypeMasterRepos, PaymentTypeMasterRepos>();
            services.AddTransient<IPaymentTypeService, PaymentTypeMasterService>();
            services.AddTransient(typeof(ICompanyRepos<>),typeof(CompanyRepos<>));
            services.AddTransient(typeof(ICompanyService<>), typeof(CompanyService<>));
            services.AddMemoryCache();
        }
    }
}