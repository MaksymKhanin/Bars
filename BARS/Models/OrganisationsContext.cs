using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BARS.Models
{
    public class OrganisationsContext:DbContext
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public OrganisationsContext() : base("LocalDb")
        { }
    }
    public class OrganisationsDbInitializer : DropCreateDatabaseAlways<OrganisationsContext>
    {
        protected override void Seed(OrganisationsContext db)
        {
            Organisation a1 = new Organisation { Name = "Ernst and Young", Type = "Financial" };
            Organisation a2 = new Organisation { Name = "Biodent", Type = "Medical" };
            Organisation a3 = new Organisation { Name = "General Motors", Type = "Industrial" };
            Organisation a4 = new Organisation { Name = "Unity Bars", Type = "IT" };

            
            db.Organisations.Add(a1);
            db.Organisations.Add(a2);
            db.Organisations.Add(a3);
            db.Organisations.Add(a4);

            Bill b1 = new Bill { Name = "11", Amount = 10000, OrganisationId = a1.Id, BookedAmount = 0 };
            Bill b2 = new Bill { Name = "21", Amount = 5000, OrganisationId = a2.Id, BookedAmount = 0 };
            Bill b3 = new Bill { Name = "31", Amount = 15000, OrganisationId = a3.Id, BookedAmount = 0 };
            Bill b4 = new Bill { Name = "41", Amount = 12000, OrganisationId = a4.Id, BookedAmount = 0 };
            
            db.Bills.Add(b1);
            db.Bills.Add(b2);
            db.Bills.Add(b3);
            db.Bills.Add(b4);

            base.Seed(db);
        }
    }
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetItemsList(); // получение всех объектов
        T GetItem(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }

    #region Organisation repository
    public class OrganisationRepository : IRepository<Organisation>
    {
        private OrganisationsContext db;

        public OrganisationRepository()
        {
            this.db = new OrganisationsContext();
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
    #endregion

    #region Bill repository
    public class BillRepository : IRepository<Bill>
    {
        private OrganisationsContext db;

        public BillRepository()
        {
            this.db = new OrganisationsContext();
        }

        public IEnumerable<Bill> GetItemsList()
        {
            return db.Bills;
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
    #endregion

    #region Operation repository
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
    #endregion
}
