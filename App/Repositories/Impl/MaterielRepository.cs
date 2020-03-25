using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class MaterielRepository : IRepository<Materiel>
    {
        private MedicalContext context;

        public MaterielRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Materiel> FindAll()
        {
            return context.Materiel;
        }
        public Materiel FindById(int id)
        {
            return context.Materiel.Find(id);
        }

        public void Insert(Materiel materiel)
        {
            context.Materiel.Add(materiel);
        }

        public void Delete(int id)
        {
            Materiel materiel = context.Materiel.Find(id);
            context.Materiel.Remove(materiel);
        }

        public void Update(Materiel materiel)
        {
            context.Entry(materiel).State = EntityState.Modified;
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
