using Core;
using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public class ProductPictuerService : Service<ProductPicture>, IProductPicture
    {
        private readonly StoreContext _context;

        public ProductPictuerService(StoreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ProductPicture productPicture)
        {
            _context.ProductPictures.Update(productPicture);
            _context.SaveChanges();
        }
    }
}
