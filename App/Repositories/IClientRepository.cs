using App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IClientRepository : IDisposable
    {
        public IEnumerable FindAll();
        public Client FindById(int id);
        public void Insert(Client model);
        public void Delete(int id);
        public void Update(Client model);
        public void Save();
    }
}
