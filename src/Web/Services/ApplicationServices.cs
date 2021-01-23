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
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IBandService, BandService>();
            services.AddTransient<ICateService, CateService>();
            services.AddTransient<IFeeService, FeeService>();
            services.AddTransient<IInfoService, InfoService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IPhoneService, PhoneService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPromotionService, PromotionService>();
            services.AddTransient<ISocialService, SocialService>();
            services.AddTransient<ITransportService, TransportService>();
            services.AddTransient<IWireService, WireService>();
            return services;
        }
    }
}