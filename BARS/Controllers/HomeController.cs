using BARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;


namespace BARS.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Organisation> db1;
        IRepository<Bill> db2;
        IRepository<Operation> db3;

        public HomeController(IRepository<Organisation> r1, IRepository<Bill> r2, IRepository<Operation> r3)
        {
            
            db1 = r1;
            db2 = r2;
            db3 = r3;
            
        }
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult Organisations()
        {
            

            return View();
        }

        public ActionResult OrganisationBills(int? id)
        {
            return View(id);
        }

        public ActionResult Transfer()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Operations()
        {
            

            return View();
        }
        
    }
}