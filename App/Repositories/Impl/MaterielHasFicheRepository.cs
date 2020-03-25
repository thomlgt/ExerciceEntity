using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Impl
{
    public class MaterielHasFicheRepository : IRepository<MaterielHasFiche>
    {
        private MedicalContext context;

        public MaterielHasFicheRepository(MedicalContext context)
        {
            this.context = context;
        }

        public IEnumerable<MaterielHasFiche> FindAll()
        {
            return context.MaterielHasFiche;
        }
        public MaterielHasFiche FindById(int id)
        {
            return context.MaterielHasFiche.Find(id);
        }

        public void Insert(MaterielHasFiche data)
        {
            context.MaterielHasFiche.Add(data);
        }

        public void Delete(int id)
        {
            MaterielHasFiche data = context.MaterielHasFiche.Find(id);
            context.MaterielHasFiche.Remove(data);
        }

        public void Update(MaterielHasFiche data)
        {
            context.Entry(data).State = EntityState.Modified;
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
