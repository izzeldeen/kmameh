using System.Collections.Generic;

namespace Core
{
    public class BasketItem
    {
        public int Id {get; set;}

        public string ProductName {get; set;}

        public decimal Price {get; set;}

        public int Quantity {get; set;}

        public List<ProductPicture> ProductPictuer {get; set;}

        public string category {get; set;}
    }
}