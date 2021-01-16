using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using Application.Enums;
using Application.Domains;

namespace Application.Interfaces.Services
{
    public interface IOrderService : IAddItem<Order>
    {
        Order GetItem(string id);
        // bool UpdateItem(string id, Order modifiedObject);
        ICollection<Order> GetListItem(DateTime start, DateTime end, EOrderStatus? status = null);
        Order ConfrimOrder(Order order,
            ICollection<OrderDetail> orderDetails,
            ICollection<BillProm> billProms,
            ICollection<Fee> fees,
            string coupon);

        ICollection<OrderStatus> GetListStatusOf(string orderId);
        bool UpdateStatus(string orderId, EOrderStatus status);
        string GetStatus(string orderId);
    }
}