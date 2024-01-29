using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyAPI.Middlewares.Authentication
{
    public class JWTBearerSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JWTOptions _options;

        public JWTBearerSetup(IOptions<JWTOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience,
                NameClaimType="name",
                IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.SecretKey))
            };
        }
    }
}
