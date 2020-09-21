using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.IService
{
    public interface IProductService : IService<Product>
    {
        void Update(Product product);
         IQueryable<Product> GetAllProduct(string? search , int? CategoryId);
         Product GetProductById(int id);
         IQueryable<Product> GetFeatuerProduct();
         IQueryable<Product> GetLatestProduct();
    }
}
