using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_ride.Controllers
{
    public class dropbikeController : Controller
    {
        RentaRidedbEntities2 db = new RentaRidedbEntities2();
        // GET: dropbike
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Droppedbike()
        {
            return View();
        }


        //[HttpPost]
        public ActionResult Save(Dropbike rebike)
        {
            if(ModelState.IsValid)
            {
                db.Dropbikes.Add(rebike);
                var bike = db.BikeRegisters.SingleOrDefault(e => e.BikeNum == rebike.BikeNumber);
                if (bike == null)
                    return HttpNotFound("Bike number not found");
                bike.Available = "yes";
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(rebike);
        }







        [HttpPost]

        public ActionResult Getid(string BikeNumber)
        {
            var bikeN = (from s in db.BikeRents
                         where s.BikeId == BikeNumber
                         select new
                         {
                             Start_Date = s.StartDate,
                             End_Date = s.EndDate,
                             Cusid = s.CustomerId,
                             Bikenum = s.BikeId,
                             Fee_ = s.Fee,
                             ElapsedDays =SqlFunctions.DateDiff("day",s.EndDate,DateTime.Now)
                         }).ToArray();

            return Json(bikeN, JsonRequestBehavior.AllowGet);
        }
    }
}