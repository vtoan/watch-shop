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
            services.AddTransient<IBaseDAO<Address>, BaseDAO<Address>>();
            services.AddTransient<IBaseDAO<Band>, BaseDAO<Band>>();
            services.AddTransient<IBaseDAO<Category>, BaseDAO<Category>>();
            services.AddTransient<IBaseDAO<Fee>, BaseDAO<Fee>>();
            services.AddTransient<IBaseDAO<InfoShop>, BaseDAO<InfoShop>>();
            services.AddTransient<IOrderDAO, OrderDAO>();
            services.AddTransient<IBaseDAO<OrderStatus>, BaseDAO<OrderStatus>>();
            services.AddTransient<IBaseDAO<Phone>, BaseDAO<Phone>>();
            services.AddTransient<IProductDAO, ProductDAO>();
            services.AddTransient<IPromotionDAO, PromoDAO>();
            services.AddTransient<IBaseDAO<Social>, BaseDAO<Social>>();
            services.AddTransient<IBaseDAO<UnitTransport>, BaseDAO<UnitTransport>>();
            services.AddTransient<IBaseDAO<Wire>, BaseDAO<Wire>>();
            return services;
        }
    }
}