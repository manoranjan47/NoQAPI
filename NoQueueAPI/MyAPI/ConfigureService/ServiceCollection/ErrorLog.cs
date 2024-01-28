using DataAccessLibrary.DBContexts;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Services;
using MyAPI.Middlewares;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class ErrorLog : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ErrorHandlingDBContext>();
            services.AddTransient<IErrorHandlingService, ErrorHandlingService>();
            services.AddTransient<IErrorHandling, ErrorHandlingRepos>();
            services.AddTransient<GlobalErrorHandlingMiddleware>();
        }
    }
}