using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace MyAPI.Middlewares.Authentication
{
    public class JWTOptionSetup : IConfigureOptions<JWTOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;
        
        public JWTOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public void Configure(JWTOptions options)
        {
            
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
