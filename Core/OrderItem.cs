using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductITemOrder itemOrdered, decimal price, int quntity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quntity = quntity;
        }

        public ProductITemOrder ItemOrdered { get; set; }

        public decimal Price { get; set; }

        public int Quntity { get; set; }
    }
}
