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
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBandService, BandService>();
            services.AddScoped<ICateService, CateService>();
            services.AddScoped<IFeeService, FeeService>();
            services.AddScoped<IInfoService, InfoService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<ISocialService, SocialService>();
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<IWireService, WireService>();
            return services;
        }
    }
}