using Microsoft.EntityFrameworkCore;
using RepoEFCosSQLWeb.Context;

namespace RepoEFCosSQLWeb.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddCosmosDb(this IServiceCollection services, string? connString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseCosmos("","","");
            });

            return services;
        }

        public static IServiceCollection AddSqlDb(this IServiceCollection services, string? connString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connString!);
            });

            return services;
        }
    }
}
