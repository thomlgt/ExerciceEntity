using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class FicheRepository : IRepository<Fiche>
    {
        private MedicalContext context;

        public FicheRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Fiche> FindAll()
        {
            return context.Fiche;
        }
        public Fiche FindById(int id)
        {
            return context.Fiche.Find(id);
        }

        public void Insert(Fiche fiche)
        {
            context.Fiche.Add(fiche);
        }

        public void Delete(int id)
        {
            Fiche fiche = context.Fiche.Find(id);
            context.Fiche.Remove(fiche);
        }

        public void Update(Fiche fiche)
        {
            context.Entry(fiche).State = EntityState.Modified;
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
