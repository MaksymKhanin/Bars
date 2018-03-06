using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class OperationRepository : IRepository<Operation>
    {
        private OrganisationsContext db;

        public OperationRepository()
        {
            this.db = new OrganisationsContext();
        }

        public IEnumerable<Operation> GetItemsList()
        {
            return db.Operations;
        }

        public Operation GetItem(int id)
        {
            return db.Operations.Find(id);
        }

        public void Create(Operation operation)
        {
            db.Operations.Add(operation);
        }

        public void Update(Operation operation)
        {
            db.Entry(operation).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Operation operation = db.Operations.Find(id);
            if (operation != null)
                db.Operations.Remove(operation);
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