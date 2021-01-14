using System;
using System.Collections.Generic;
using Application.Data;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class OrderService : AbstractService<Order>, IOrderService
    {
        public OrderService(IBaseDAO<Order> db, ICache cache) : base(db, cache) { }

        public Order ConfrimOrder(Order order, ICollection<OrderDetail> orderDetails)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetListItem(DateTime start, DateTime end, EOrderStatus? status = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderStatus> GetListStatus(string orderId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatus(int orderId, EOrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}