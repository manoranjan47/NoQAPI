using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Middlewares.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class AuthenticationAuthorization : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<UserData, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDBContext>()
                            .AddDefaultTokenProviders();
            services.ConfigureOptions<JWTOptionSetup>();
            ////services.ConfigureOptions<JWTBearerSetup>();
            ////services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            ////    .AddJwtBearer();

            services.AddTransient<IJWTProvider, JWTProvider>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    NameClaimType = "name",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mhysyHGgsdhkjaytfbjhW67GJH@&^Vhjvxd")),
                };
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        }
    }
}
