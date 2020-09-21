using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface ICategoryService : IService<Category>
    {
        void Update(Category category);

        public List<Category> GetAllCategories();
    }
}
