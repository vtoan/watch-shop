using System;
using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IOrderDAO : IGet<Order>, IAdd<Order>, IUpdate<Order>
    {
        Order Get(string id);
        ICollection<Order> GetList(DateTime start, DateTime end, int status);
        ICollection<OrderStatus> GetListStatus(string orderId);

    }
}