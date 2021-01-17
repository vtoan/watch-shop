using Application.Domains;
using Application.Interfaces.DAOs;
using Infrastructure.DAOs;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Services
{
    public static class DAOServices
    {
        public static IServiceCollection AddDAOService(this IServiceCollection services)
        {
            services.AddScoped<IBaseDAO<Address>, BaseDAO<Address>>();
            services.AddScoped<IBaseDAO<Band>, BaseDAO<Band>>();
            services.AddScoped<IBaseDAO<Category>, BaseDAO<Category>>();
            services.AddScoped<IBaseDAO<Fee>, BaseDAO<Fee>>();
            services.AddScoped<IBaseDAO<InfoShop>, BaseDAO<InfoShop>>();
            services.AddScoped<IOrderDAO, OrderDAO>();
            services.AddScoped<IBaseDAO<OrderStatus>, BaseDAO<OrderStatus>>();
            services.AddScoped<IBaseDAO<Phone>, BaseDAO<Phone>>();
            services.AddScoped<IProductDAO, ProductDAO>();
            services.AddScoped<IPromotionDAO, PromoDAO>();
            services.AddScoped<IBaseDAO<Social>, BaseDAO<Social>>();
            services.AddScoped<IBaseDAO<UnitTransport>, BaseDAO<UnitTransport>>();
            services.AddScoped<IBaseDAO<Wire>, BaseDAO<Wire>>();
            return services;
        }
    }
}