using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BARS.Models;

namespace BARS.Controllers
{
    public class OrganisationsController : ApiController
    {

        private readonly IRepository<Organisation> db1;


        public OrganisationsController(IRepository<Organisation> r1)
        {
            db1 = r1;

        }

        public OrganisationsController()
        {

        }
        // GET: api/Values
        [HttpGet]
        public IEnumerable<OrganisationViewModel> GetOrganisations()
        {
            List<OrganisationViewModel> organisationViewModels = new List<OrganisationViewModel>();
            var organisations = db1.GetItemsList();
            foreach (var org in organisations)
            {
                var organisationViewModel = new OrganisationViewModel
                {
                    Id = org.Id,
                    Name = org.Name,
                    Type = org.Type
                };
                organisationViewModels.Add(organisationViewModel);
            }
            return organisationViewModels;
        }

        // GET: api/Values/5
        [HttpGet]
        public OrganisationViewModel GetOrganisation(int id)
        {
            Organisation organisation = db1.GetItem(id);
            return new OrganisationViewModel
            {
                Id = organisation.Id,
                Name = organisation.Name,
                Type = organisation.Type
            };
        }

        // POST: api/Values
        [HttpPost]
        public void PostOrganisation(Organisation organisation)
        {
            db1.Create(organisation);
            db1.Save();
        }

        // PUT: api/Values/5
        [HttpPut]
        public void PutOrganisation(Organisation organisation)
        {
            if (organisation != null && ModelState.IsValid)
            {
                if (organisation.Id != 0)
                {
                    db1.Update(organisation);

                    db1.Save();
                }
            }
            
        }

        // DELETE: api/Values/5
        [HttpDelete]
        public void DeleteOrganisation(Organisation organisation)
        {
            db1.Delete(organisation.Id);
            db1.Save();
        }
        protected override void Dispose(bool disposing)
        {
            db1.Dispose();
            base.Dispose(disposing);
        }
    }
}
