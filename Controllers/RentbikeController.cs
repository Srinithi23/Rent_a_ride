using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_ride.Controllers
{
    public class RentbikeController : Controller
    {
        RentaRidedbEntities2 db = new RentaRidedbEntities2();

        // GET: Rentbike
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Getbike()
        {
            var bike = db.BikeRegisters.ToList();
            return Json(bike, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.Customers where s.CustomerId == id select s.CustomerName).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavil(String BikeNum)
        {
            var bikeavil = (from s in db.BikeRegisters where s.BikeNum == BikeNum select s.Available).FirstOrDefault();
            return Json(bikeavil, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Save(BikeRent rent)
        {
            if(ModelState.IsValid)
            {
                db.BikeRents.Add(rent);
                var bike = db.BikeRegisters.SingleOrDefault(e => e.BikeNum == rent.BikeId);
                if (bike == null)
                    return HttpNotFound("Bike Number is not valid");
                bike.Available = "no";
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rent);
        }


    }   
}