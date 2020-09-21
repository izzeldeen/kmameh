using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ArName { get; set; }

        public int CategoryID { get; set; }

        public string CategryName { get; set; }

        public string CategoryArName { get; set; }

        public decimal Price { get; set; }

        public bool IsOutOfStoucl { get; set; }

        public List<ProductPicture> ProductPictures { get; set; }

        public string SupplierName { get; set; }


    }
}
