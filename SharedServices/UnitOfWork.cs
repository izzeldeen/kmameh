using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
   public  class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;

            Category = new CategoryService(_context);
            Product = new ProductService(_context);
            ProductSpecification = new ProductSpecification(_context);
            Supplier = new SupplierSerivces(_context);
            Pictuer = new PictuerService(_context);
            ProductPicture = new ProductPictuerService(_context);
            OrderService = new OrderService(_context);
           }

        public ICategoryService Category { get; private set; }

        public ICustomerBasketService CustomerBasket {get; private set;}

        public IProductService Product { get; private set; }

        public IProductPicture ProductPicture { get; private set; }

        public ISuplierService Supplier { get; private set; }

        public IPictuerService Pictuer { get; private set; }

        public IProductSpecification ProductSpecification { get; private set; }

        public IOrderService OrderService { get; private set; }

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
