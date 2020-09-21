using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ProductITemOrder : BaseEntity
    {
        public ProductITemOrder()
        {
        }

        public ProductITemOrder(int productIntId, string productName, string pictuerUrl)
        {
            ProductIntId = productIntId;
            ProductName = productName;
            PictuerUrl = pictuerUrl;
        }


        public int ProductIntId { get; set; }

        public string ProductName { get; set; }

        public string  PictuerUrl { get; set; }


    }
}
