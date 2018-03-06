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
    public class OrganisationsDbInitializer : CreateDatabaseIfNotExists<OrganisationsContext>
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
        IEnumerable<T> GetOrganisationsList(); // получение всех объектов
        T GetOrganisation(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }

    public class ApplicationRepository : IRepository<Organisation>
    {
        private OrganisationsContext db;

        public ApplicationRepository()
        {
            this.db = new OrganisationsContext();
        }

        public IEnumerable<Organisation> GetOrganisationsList()
        {
            return db.Organisations;
        }

        public Organisation GetOrganisation(int id)
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
