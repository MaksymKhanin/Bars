using BARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARS.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Organisation> db1;
        IRepository<Bill> db2;
        IRepository<Operation> db3;

        public HomeController()
        {
            db1 = new OrganisationRepository();
            db2 = new BillRepository();
            db3 = new OperationRepository();
        }
        public ActionResult Index()
        {
            var bills = db2.GetItemsList();
            ViewBag.Bills = bills;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}