using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class ClientRepository : IRepository<Client>
    {
        private MedicalContext context;

        public ClientRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> FindAll()
        {
            return context.Client;
        }
        public Client FindById(int id)
        {
            return context.Client.Find(id);
        }

        public void Insert(Client client)
        {
            context.Client.Add(client);
        }

        public void Delete(int id)
        {
            Client client = context.Client.Find(id);
            context.Client.Remove(client);
        }

        public void Update(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
