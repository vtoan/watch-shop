using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.DAOs;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services)
        { //
            services.AddScoped<IProductDAO, ProductDAO>();

            services.AddScoped<IProductService, ProductService>();

            //
            return services;
        }
    }
}