using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class AdresseRepository : IRepository<Adresse>
    {
        private MedicalContext context;

        public AdresseRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Adresse> FindAll()
        {
            return context.Adresse;
        }
        public Adresse FindById(int id)
        {
            return context.Adresse.Find(id);
        }

        public void Insert(Adresse adresse)
        {
            context.Adresse.Add(adresse);
        }

        public void Delete(int id)
        {
            Adresse adresse = context.Adresse.Find(id);
            context.Adresse.Remove(adresse);
        }

        public void Update(Adresse adresse)
        {
            context.Entry(adresse).State = EntityState.Modified;
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
