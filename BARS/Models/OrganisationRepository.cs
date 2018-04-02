using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class OrganisationRepository : IRepository<Organisation>
    {
        private OrganisationsContext db;

        public OrganisationRepository(OrganisationsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Organisation> GetItemsList(int id)
        {
            return db.Organisations;
        }

        public IEnumerable<Organisation> GetItemsList()
        {
            return db.Organisations;
        }

        public Organisation GetItem(int id)
        {
            return db.Organisations.Find(id);
        }

        public void Create(Organisation organisation)
        {
            db.Organisations.Add(organisation);
        }

        public void Update(Organisation organisation)
        {
            db.Entry(organisation).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            if (organisation != null)
                db.Organisations.Remove(organisation);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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