using Core;
using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public class ProductSpecification : Service<Core.ProductSpecification>, IProductSpecification
    {
        private readonly StoreContext _context;
        public ProductSpecification(StoreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Core.ProductSpecification productSpecification)
        {
            _context.ProductSpecifications.Update(productSpecification);
            _context.SaveChanges();
         }
    }
}
