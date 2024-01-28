using DataAccessLibrary;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Services;
using DataAccessLibrary.DBContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class DBContext : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("conStr");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
           /* services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>()
            .AddDefaultTokenProviders();*/

            services.AddTransient<PaymentTypeMasterDBContext>();
            services.AddTransient<NoQContext>();

        }
    }
}