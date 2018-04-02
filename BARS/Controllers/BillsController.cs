using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BARS.Models;

namespace BARS.Controllers
{
    public class BillsController : ApiController
    {
        private readonly IRepository<Bill> db2;

        public BillsController(IRepository<Bill> r2)
        {
            db2 = r2;
        }

        [HttpGet]
        public HttpResponseMessage GetBills(int id)
        {

            List<BillViewModel> billViewModels = new List<BillViewModel>();

            var bills = db2.GetItemsList(id);
            foreach (var bill in bills)
            {
                var billViewModel = new BillViewModel
                {
                    Id = bill.Id,
                    Name = bill.Name,
                    Amount = bill.Amount,
                    BookedAmount = bill.BookedAmount,
                    FreeAmount = bill.FreeAmount,
                    OrganisationId = bill.OrganisationId,
                    OrganisationName = bill.Organisation.Name,
                    OrganisationType = bill.Organisation.Type
                };
                billViewModels.Add(billViewModel);
            }

            return Request.CreateResponse(HttpStatusCode.OK, billViewModels);
        }
        // GET: api/Bills
        [HttpGet]
        public IEnumerable<BillViewModel> GetBills()
        {

            List<BillViewModel> billViewModels = new List<BillViewModel>();

            var bills = db2.GetItemsList();
            foreach (var bill in bills)
            {
                var billViewModel = new BillViewModel
                {
                    Id = bill.Id,
                    Name = bill.Name,
                    Amount = bill.Amount,
                    BookedAmount = bill.BookedAmount,
                    FreeAmount = bill.FreeAmount,
                    OrganisationId = bill.OrganisationId,
                    OrganisationName = bill.Organisation.Name,
                    OrganisationType = bill.Organisation.Type
                };
                billViewModels.Add(billViewModel);
            }

            return billViewModels;
        }

        // GET: api/Bills/5
        [HttpGet]
        public BillViewModel GetBill(int id)
        {
            Bill bill = db2.GetItem(id);
            return new BillViewModel
            {
                Id = bill.Id,
                Name = bill.Name,
                Amount = bill.Amount,
                BookedAmount = bill.BookedAmount,
                FreeAmount = bill.FreeAmount,
                OrganisationId = bill.OrganisationId,
                OrganisationName = bill.Organisation.Name,
                OrganisationType = bill.Organisation.Type
            };

        }

        // POST: api/Bills
        [HttpPost]
        public void PostBill([FromBody]Bill bill)
        {
            db2.Create(bill);
            db2.Save();
        }

        // PUT: api/Bills/5
        [HttpPut]
        public void PutBill([FromBody]Bill bill)
        {
            
           
            {
                db2.Update(bill);

                db2.Save();
            }
        }

        // DELETE: api/Bills/5
        [HttpDelete]
        public void Delete(Bill bill)
        {
            db2.Delete(bill.Id);
            db2.Save();
        }
        
        protected override void Dispose(bool disposing)
        {
            db2.Dispose();
            base.Dispose(disposing);
        }
    }
}
