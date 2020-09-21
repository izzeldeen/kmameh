using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly StoreContext _context;
        internal DbSet<T> dbSet;

        public Service(StoreContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity) => dbSet.Add(entity);
       

        public T Get(int id) => dbSet.Find(id);

        public void Remove(T entity) => dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entity) => dbSet.RemoveRange(entity);


        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

      






    }
}
