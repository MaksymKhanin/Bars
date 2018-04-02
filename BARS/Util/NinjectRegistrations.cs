using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BARS.Models;
using Ninject.Modules;  

namespace BARS.Util
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Organisation>>().To<OrganisationRepository>();
            Bind<IRepository<Bill>>().To<BillRepository>();
            Bind<IRepository<Operation>>().To<OperationRepository>();
        }
    }
}