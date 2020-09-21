using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface IService<T> where T : class
    {
        T Get(int id);

        public void Add(T entity);

        public void Remove(T entity);

        public void Remove(int id);

        public void RemoveRange(IEnumerable<T> entity);

    }
}
