using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parking.Models;

namespace parking.Controllers
{
    public class HomeController : Controller
    {
        private ParkingEntities1 db = new ParkingEntities1();
        public ActionResult Index()
        {
            ViewBag.zi = db.Parking.Where(p => p.StatusP != 1).Count();
            ViewBag.user = User.Identity.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}