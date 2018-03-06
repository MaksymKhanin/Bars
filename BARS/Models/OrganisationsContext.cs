using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BARS.Models
{
    public class OrganisationsContext : DbContext
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
}
