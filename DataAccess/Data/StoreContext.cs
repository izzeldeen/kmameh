
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
     public class StoreContext : IdentityDbContext 
     {
         public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

       }

        public DbSet<Product>   Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DbSet<ProductCost> ProductCosts { get; set; }

        public DbSet<ProductSpecification> ProductSpecifications { get; set; }

        public DbSet<ProductITemOrder> ProductItemOrder { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DbSet<User> Users {get; set;}

       
    }

}