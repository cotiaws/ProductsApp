using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProductsApp.API.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //JWT Bearer
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //JWT Bearer
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]))
                };
            });

            return services;
        }
    }
}
