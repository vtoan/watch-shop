using Application.Interfaces.Helper;
using Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Services
{
    public static class HelpfulServices
    {

        public static IServiceCollection AddHelpfulServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICache, CacheHelper>();
            services.AddScoped<IEmailSender, ConfigMail>();
            return services;
        }
    }
}