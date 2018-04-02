using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BARS.Models;

namespace BARS.Controllers
{
    public class OperationsController : ApiController
    {

        
        private readonly IRepository<Operation> db3;

        public OperationsController( IRepository<Operation> r3)
        {
           
            db3 = r3;
        }

        // GET: api/Operations
        public IEnumerable<OperationViewModel> GetOperations()
        {
            List<OperationViewModel> operViewModels = new List<OperationViewModel>();

            var opers = db3.GetItemsList();
            foreach (var oper in opers)
            {
                var operViewModel = new OperationViewModel
                {
                    Id = oper.Id,
                    Date=oper.Date,
                    Action = oper.Action,
                    Amount = oper.Amount,
                    BillFromId = oper.BillFromId,
                    BillToId = oper.BillToId,
                    BillFromName = oper.BillFrom.Name,
                    BillToName = oper.BillTo.Name,
                    OrganisationFromName = oper.BillFrom.Organisation.Name,
                    OrganisationToName = oper.BillTo.Organisation.Name,
                };
                operViewModels.Add(operViewModel);
            }

            return operViewModels;
        }

        // GET: api/Operations/5
        public Operation GetOperations(int id)
        {
            Operation operation = db3.GetItem(id);
            return operation;
        }

        // POST: api/Operations
        public void PostOperation([FromBody]Operation operation)
        {
            DateTime date = DateTime.Now;
            Operation oper = new Operation
            {
                Id = operation.Id,
                Date = date,
                Action = operation.Action,
                Amount = operation.Amount,
                BillFromId = operation.BillFromId,
                BillToId = operation.BillToId
                
            };
            
            db3.Create(oper);
            //b3.Save();
        }

        // PUT: api/Operations/5
        public void PutOperation(int id, [FromBody]Operation operation)
        {
            if (id == operation.Id)
            {
                db3.Update(operation);

                db3.Save();
            }
        }

        // DELETE: api/Operations/5
        public void DeleteOperation(int id)
        {
            db3.Delete(id);
            db3.Save();
        }
        protected override void Dispose(bool disposing)
        {
            db3.Dispose();
            base.Dispose(disposing);
        }
    }
}
