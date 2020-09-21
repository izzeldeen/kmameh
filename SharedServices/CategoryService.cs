using Core;
using DataAccess.Data;
using SharedServices.IService;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SharedServices
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly StoreContext _context;

        public CategoryService(StoreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public  List<Category> GetAllCategories() =>  _context.Categories.ToList();
    }
}
