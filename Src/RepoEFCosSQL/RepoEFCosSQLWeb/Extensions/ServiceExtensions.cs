using Microsoft.EntityFrameworkCore;
using RepoEFCosSQLWeb.Context;

namespace RepoEFCosSQLWeb.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddCosmosDb(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "RepoEFCosDb");
            });

            return services;
        }

        public static IServiceCollection AddSqlDb(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
                options.UseSqlServer(
                    "Data Source=.\\;Initial Catalog=RepoEFCosDb;User Id=RepoEFCosDbUser;Password=Hsy126654**;");
            });

            return services;
        }
    }
}
