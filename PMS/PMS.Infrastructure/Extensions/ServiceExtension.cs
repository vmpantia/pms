using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.Infrastructure.Databases.Contexts;
using PMS.Infrastructure.Databases.Repositories;
using PMS.Shared.Contracts.Repositories;

namespace PMS.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddIntrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabases(configuration);
            services.AddRepositories();
        }

        private static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PMSDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWorkItemRepository, WorkItemRepository>();
        }
    }
}
