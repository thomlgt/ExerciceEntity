using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class CategorieRepository : IRepository<Categorie>
    {
        private MedicalContext context;

        public CategorieRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categorie> FindAll()
        {
            return context.Categorie;
        }
        public Categorie FindById(int id)
        {
            return context.Categorie.Find(id);
        }

        public void Insert(Categorie categorie)
        {
            context.Categorie.Add(categorie);
        }

        public void Delete(int id)
        {
            Categorie categorie = context.Categorie.Find(id);
            context.Categorie.Remove(categorie);
        }

        public void Update(Categorie categorie)
        {
            context.Entry(categorie).State = EntityState.Modified;
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
