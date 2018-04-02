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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                        .HasRequired(m => m.BillFrom)
                        .WithMany(t => t.OperationsFrom)
                        .HasForeignKey(m => m.BillFromId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                        .HasRequired(m => m.BillTo)
                        .WithMany(t => t.OperationsTo)
                        .HasForeignKey(m => m.BillToId)
                        .WillCascadeOnDelete(false);

            //Database.SetInitializer<OrganisationsContext>(null);
        }
    }
    public class OrganisationsDbInitializer : DropCreateDatabaseIfModelChanges<OrganisationsContext>
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

            Bill b1 = new Bill { Name = "11", Amount = 10000, Organisation = a1, BookedAmount = 0 };
            Bill b2 = new Bill { Name = "21", Amount = 5000, Organisation = a2, BookedAmount = 0 };
            Bill b3 = new Bill { Name = "31", Amount = 15000, Organisation = a3, BookedAmount = 0 };
            Bill b4 = new Bill { Name = "41", Amount = 12000, Organisation = a4, BookedAmount = 0 };

            db.Bills.Add(b1);
            db.Bills.Add(b2);
            db.Bills.Add(b3);
            db.Bills.Add(b4);

            base.Seed(db);
        }


    }
}
