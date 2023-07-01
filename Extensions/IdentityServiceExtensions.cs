using JwtWebApi.Helpers;
using JwtWebApi.Utils;
using JwtWebApi.Utils.Contracts;

namespace JwtWebApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration config)
        {
            // Register JWT
            services.Configure<AppSettings>(config.GetSection("AppSettings"));
            services.AddScoped<IJwtUtil, JwtUtil>();

            return services;
        }
    }
}