using JwtWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAppilication(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<JwtWebApiDbContext>(options =>
            {
                options.UseMySQL(config.GetConnectionString("MySqlConnection"));
            });

            return services;
        }
    }
}