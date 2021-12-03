using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelpYourCity.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("HelpYourCity.API")
                ));
            return services;
        }
    }
}