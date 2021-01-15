using System;
using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IOrderDAO : IAdd<Order>
    {
        Order Get(string id);
        bool Update(string id, Dictionary<string, object> newObject);
        ICollection<Order> GetList(DateTime start, DateTime end, int status);
        ICollection<OrderStatus> GetListStatusOf(string orderId);
        OrderStatus AddLogStatus(string OrderId, int status);

    }
}