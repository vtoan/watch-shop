using System;
namespace Application.Domains
{
    public class OrderStatus
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public byte? Status { get; set; }

        public DateTime DateChanged { get; set; }
        //Nav
        public Order Order { get; set; }

    }
}