using DataAccessLibrary.DBContexts;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Services;
using MyAPI.Middlewares;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class SecurityServices : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: configuration.GetSection("specficationString").ToString(),
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:5024/");
                                  });
            });
        }
    }
}