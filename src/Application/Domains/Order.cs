using System;
using System.Collections.Generic;

namespace Application.Domains
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string Note { get; set; }
        public string UnitTranspost { get; set; }
        public string Promotions { get; set; }
        public string Fees { get; set; }
        public int? Status { get; set; }
        public int? CustomerId { get; set; }
        //Nav property
        public List<OrderDetail> OrderDetails { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }
    }
}