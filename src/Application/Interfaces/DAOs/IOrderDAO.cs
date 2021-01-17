using System;
using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IOrderDAO
    {
        Order Add(Order newObject);
        int GetStatus(string orderId);
        Order Get(string id);
        ICollection<Order> GetList(DateTime start, DateTime end, int status);
        ICollection<OrderStatus> GetListStatusOf(string orderId);
        OrderStatus AddLogStatus(OrderStatus newObject);

    }
}