using System;
using System.Collections.Generic;
using Application.Data;
using Application.Domains;

namespace Application.Interfaces.Services
{
    public interface IOrderService : IAddItem<Order>, IGetItem<Order>, IUpdateItem<Order>
    {
        ICollection<Order> GetListItem(DateTime start, DateTime end, EOrderStatus? status = null);
        Order ConfrimOrder(Order order, ICollection<OrderDetail> orderDetails);
        bool UpdateStatus(int orderId, EOrderStatus status);
        ICollection<OrderStatus> GetListStatus(string orderId);
    }
}