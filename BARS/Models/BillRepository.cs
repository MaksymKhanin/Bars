using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class BillRepository : IRepository<Bill>
    {
        private OrganisationsContext db;

        public BillRepository(OrganisationsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Bill> GetItemsList(int id)
        {
            return db.Bills.Include(p => p.Organisation).Where(at => at.OrganisationId == id).ToList();
        }
        public IEnumerable<Bill> GetItemsList()
        {
            return db.Bills.Include(p=>p.Organisation).ToList();
        }

        public Bill GetItem(int id)
        {
            return db.Bills.Find(id);
        }

        public void Create(Bill bill)
        {
            db.Bills.Add(bill);
        }

        public void Update(Bill bill)
        {
            db.Entry(bill).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Bill bill = db.Bills.Find(id);
            if (bill != null)
                db.Bills.Remove(bill);
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