using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class OrderStatusService : AbstractService<OrderStatus>, IOrderStatusService
    {
        public OrderStatusService(IBaseDAO<OrderStatus> db) : base(db)
        {
        }
    }
}