using Microsoft.Extensions.Options;
using PMS.Web.Common;
using PMS.Web.Contracts;
using PMS.Web.Services;
using PMS.Web.Settings;

namespace PMS.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PMSApiSetting>(configuration.GetSection($"ApiSettings:{Constant.PMS_API}"));
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient(Constant.PMS_API, (sp, client) =>
            {
                var setting = sp.GetRequiredService<IOptions<PMSApiSetting>>();
                client.BaseAddress = new Uri(setting.Value.BaseAddress);
            });
        }

        public static void AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IPMSService, PMSService>();
        }
    }
}
