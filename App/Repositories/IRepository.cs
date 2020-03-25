using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        public IEnumerable<T> FindAll();
        public T FindById(int id);
        public void Insert(T model);
        public void Delete(int id);
        public void Update(T model);
        public void Save();
    }
}
