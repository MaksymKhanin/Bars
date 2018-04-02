using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class OperationRepository : IRepository<Operation>
    {
        private OrganisationsContext db;

        public OperationRepository(OrganisationsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Operation> GetItemsList(int id)
        {
            return db.Operations;
        }
        public IEnumerable<Operation> GetItemsList()
        {
            return db.Operations.Include(p => p.BillTo.Organisation).Include(p => p.BillFrom.Organisation);
        }

        public Operation GetItem(int id)
        {
            return db.Operations.Find(id);
        }

        public void Create(Operation operation)
        {
            db.Operations.Add(operation);
            db.Entry(operation).State = EntityState.Added;

            if (operation.Action == "transfer")
            {
                var billFrom = db.Bills.Find(operation.BillFromId);
                billFrom.Amount = billFrom.Amount - operation.Amount;
                db.Entry(billFrom).State = EntityState.Modified;

                var billTo = db.Bills.Find(operation.BillToId);
                billTo.Amount = billTo.Amount + operation.Amount;
                db.Entry(billTo).State = EntityState.Modified;
            }

            db.SaveChanges();
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