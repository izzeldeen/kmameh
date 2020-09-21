using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(string buyerEmail, string name, DateTimeOffset orderDate, List<OrderItem> orderItems, decimal shippingPrice, decimal subtotal, OrderStatus status, string paymenIntId)
        {
            BuyerEmail = buyerEmail;
            Name = name;
            OrderItems = orderItems;
            ShippingPrice = shippingPrice;
            Subtotal = subtotal;
           
        }

        public string BuyerEmail { get; set; }

        public string Name { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public List<OrderItem> OrderItems { get; set; }

        public decimal ShippingPrice { get; set; } = 0;

        public decimal Subtotal { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public string PaymenIntId { get; set; }


        public decimal GetTotal()
        {
            return Subtotal + ShippingPrice;
        }

    }
}
