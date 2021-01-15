using System;
using System.Collections.Generic;
using Application.Enums;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using System.Text.Json;
using System.Linq;

namespace Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderDAO _dao;
        public OrderService(IOrderDAO dao)
        {
            _dao = dao;
        }

        public bool UpdateItem(string id, Order modifiedObject)
        {
            if (String.IsNullOrEmpty(id) || modifiedObject == null) return false;
            var modified = GetPropChangedOf(modifiedObject);
            if (modified.Count <= 0) return true;
            return _dao.Update(id, modified);
        }

        public Order GetItem(string id)
        {
            if (String.IsNullOrEmpty(id)) return null;
            return _dao.Get(id);
        }

        public Order ConfrimOrder(Order order,
            ICollection<OrderDetail> orderDetails,
            ICollection<BillProm> billProms,
            ICollection<Fee> fees)
        {
            order.Fees = fees?.Count == 0 ? null : JsonSerializer.Serialize(fees);
            int totalQuantity = 0;
            double totalOrder = 0;
            foreach (var item in orderDetails)
            {
                double CurrDiscount = 1;
                if (item.Discount != null || item?.Discount > 0)
                    CurrDiscount = (double)((item.Discount % 1 == 0) ? item.Discount : (item.Price * item.Discount));
                totalQuantity += (int)item.Quantity;
                totalOrder += ((int)item.Price - CurrDiscount) * (int)item.Quantity;
            }
            order.Promotions = null;
            foreach (var item in billProms)
            {
                if (item.ConditionAmount != null && totalOrder >= item.ConditionAmount)
                {
                    order.Promotions = JsonSerializer.Serialize(item.Discount);
                    break;
                }
                if (item.ConditionItem != null && totalQuantity >= item.ConditionItem)
                {
                    order.Promotions = JsonSerializer.Serialize(item.Discount);
                    break;
                }
            }
            return order;
        }

        public ICollection<Order> GetListItem(DateTime start, DateTime end, EOrderStatus? status = null)
        {
            int stt = status == null ? 0 : (int)status?.GetTypeCode();
            return _dao.GetList(start, end, stt);
        }

        public ICollection<OrderStatus> GetListStatusOf(string orderId)
        {
            if (String.IsNullOrEmpty(orderId)) return null;
            return _dao.GetListStatusOf(orderId);
        }

        public bool UpdateStatus(string orderId, EOrderStatus status)
        {
            if (String.IsNullOrEmpty(orderId)) return false;
            int stt = (int)status.GetTypeCode();
            var propModified = CreatePropChanged("status", stt);
            var execResult = _dao.Update(orderId, propModified);
            if (!execResult) return false;
            return _dao.AddLogStatus(orderId, stt) == null;
        }

        public Order AddItem(Order newObject)
        {
            if (newObject == null) return null;
            newObject.DateCreated = DateTime.Now;
            newObject.Status = (byte)EOrderStatus.NotConfirm.GetTypeCode();
            return _dao.Add(newObject);
        }

    }
}