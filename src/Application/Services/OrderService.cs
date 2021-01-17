using System;
using System.Collections.Generic;
using Application.Enums;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using System.Text.Json;
using System.Linq;
using Application.Interfaces.Helper;

namespace Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderDAO _dao;
        private readonly IEmailSender _emailSender;
        public OrderService(IOrderDAO dao, IEmailSender email)
        {
            _dao = dao;
            _emailSender = email;
        }

        public Order GetItem(string id)
        {
            if (String.IsNullOrEmpty(id)) return null;
            return _dao.Get(id);
        }

        public Order ConfrimOrder(Order order,
            ICollection<OrderDetail> orderDetails,
            ICollection<BillProm> billProms,
            ICollection<Fee> fees,
            string coupon)
        {
            order.Fees = fees?.Count == 0 ? null : JsonSerializer.Serialize(fees);
            order.Promotions = FindBillPromo(orderDetails, billProms).ToString();
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
            var ods = new OrderStatus() { OrderId = orderId, Status = (byte?)status, DateChanged = DateTime.Now };
            return _dao.AddLogStatus(ods) == null;
        }

        public Order AddItem(Order newObject)
        {
            if (newObject == null) return null;
            newObject.Id = GeneratorOrderId();
            newObject.DateCreated = DateTime.Now;
            var execResult = _dao.Add(newObject);
            if (execResult != null) _emailSender.Send("New Order", JsonSerializer.Serialize(execResult));
            this.UpdateStatus(execResult.Id, EOrderStatus.NotConfirm);
            return execResult;
        }

        public string GetStatus(string orderId)
        {
            if (String.IsNullOrEmpty(orderId)) return null;
            var odStt = _dao.GetStatus(orderId);
            switch (odStt)
            {
                case 0: return EOrderStatus.Cancel.ToString();
                case 1: return EOrderStatus.NotConfirm.ToString();
                case 2: return EOrderStatus.Confirmed.ToString();
            }
            return null;
        }

        private string GeneratorOrderId()
        {
            char[] arChar = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J' };
            string orderId = "";
            Random rm = new Random();
            for (int i = 0; i < 3; i++)
                orderId += arChar[rm.Next(0, 8)];
            orderId += DateTime.Now.Millisecond;
            return orderId;
        }

        private double FindBillPromo(ICollection<OrderDetail> orderDetails, ICollection<BillProm> billProms)
        {
            if (orderDetails?.Count == 0 || billProms?.Count == 0) return 0;
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
            foreach (var item in billProms)
            {
                if (item.ConditionAmount != null &&
                    item.ConditionItem != null)
                {
                    if (totalQuantity >= item.ConditionItem && totalOrder >= item.ConditionAmount)
                    {
                        return (double)item.Discount;
                    }
                }
                if (item.ConditionItem != null && totalQuantity >= item.ConditionItem)
                {
                    return (double)item.Discount;

                }
                if (item.ConditionAmount != null && totalOrder >= item.ConditionAmount)
                {
                    return (double)item.Discount;
                }
            }
            return 0;
        }
    }
}