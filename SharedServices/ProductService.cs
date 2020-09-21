using Core;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context) : base(context)
        {
            _context = context;
        }

        public   IQueryable<Product> GetAllProduct(string? search , int? CategoryId)
        {
            var products = _context.Products.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                products = _context.Products.Where(x=> x.Name.Contains(search)).Include(x => x.Category).Include(x => x.Supplier).Include(x => x.ProductPictures).ThenInclude(x => x.Picture);
            }

            if(CategoryId != 0)
            {
                products = _context.Products.Where(x => x.CategoryID == CategoryId).Include(x => x.Category).Include(x => x.Supplier).Include(x => x.ProductPictures).ThenInclude(x => x.Picture);

            }

            if(string.IsNullOrEmpty(search) && CategoryId == 0)
            {
                products = _context.Products.Include(x => x.Category).Include(x => x.Supplier).Include(x => x.ProductPictures).ThenInclude(x => x.Picture);
            }
           

            return products;
        }

        public IQueryable<Product> GetFeatuerProduct()
       
         =>    _context.Products.Take(4).Include(x=> x.Category)
               .Include(x=> x.Supplier)
               .Include(x => x.ProductPictures)
               .ThenInclude(x => x.Picture);


        public IQueryable<Product> GetLatestProduct()
        => _context.Products.OrderByDescending(x=>x.ModifiedOn).Take(4).Include(x=> x.Category)
               .Include(x=> x.Supplier)
               .Include(x => x.ProductPictures)
               .ThenInclude(x => x.Picture);

        public Product GetProductById(int id) =>  _context.Products.Include(x=>x.Category).
            Include(x => x.ProductCosts).Include(x => x.Supplier)
            .Include(x => x.ProductPictures)
            .ThenInclude(x => x.Picture).FirstOrDefault(x => x.ID == id);


        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }


    }
}
