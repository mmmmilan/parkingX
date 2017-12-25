using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parking.Models;

namespace parking.Controllers
{
    public class ParkingController : Controller
    {
        private ParkingEntities1 db = new ParkingEntities1();
        // GET: Parking
        public ActionResult Index()
        {
            ViewBag.user = User.Identity.Name;
            ViewBag.slobodno = db.Parking.Select(p => p).Where(p => p.StatusP < 1).Count();
            ViewBag.zi = db.Parking.Where(p => p.StatusP != 1).Count();
            return View();
        }

        public JsonResult VratiParkinge()
        {
            var parkinzi = db.Parking.Select(p => new { ID = p.SpotId, NeighID = p.NeighId, Status = p.StatusP, Msg = p.Note }).OrderBy(p => p.ID);

            return Json(parkinzi, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public string proveri(int? id)
        {
            string rezult = "";
            ViewBag.z = db.Parking.Select(p => p).Where(p => p.NeighId == 2).Count();
            return rezult;
        }

        [HttpPost]
        public ActionResult Promeni([Bind(Include = "SpotId,NeighID,StatusP,ArriveT,Note")] Parking p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}