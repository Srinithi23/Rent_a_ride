using Rent_a_ride.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_ride.Controllers
{
    public class RentcarController : Controller
    {

        RentaRidedbEntities2 db = new RentaRidedbEntities2();
        // GET: Rentcar
        public ActionResult Index()
        {
            var result = (from r in db.CarRents
                          join c in db.CarRegisters on r.CarId equals c.CarNum

                          select new RentViewModel
                          {
                              Id = r.Id,
                              CarId = r.CarId,
                              CustomerId=r.CustomerId,
                              Fee=r.Fee,
                              StartDate=r.StartDate,
                              EndDate=r.EndDate,
                              Available=c.Available


                          }).ToList();
            return View(result);
        }





        //[HttpGet]
        //public ActionResult Getbike()
        //{
        //    var bike = db.BikeRegisters.ToList();
        //    return Json(bike, JsonRequestBehavior.AllowGet);
        //}


        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.CarRegisters.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }





        //[HttpPost]
        //public ActionResult Getid(int id)
        //{
        //    var customer = (from s in db.Customers where s.CustomerId == id select s.CustomerName).ToList();
        //    return Json(customer, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.Customers where s.CustomerId == id select s.CustomerName).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }




        //[HttpPost]
        //public ActionResult Getavil(String BikeNum)
        //{
        //    var bikeavil = (from s in db.BikeRegisters where s.BikeNum == BikeNum select s.Available).FirstOrDefault();
        //    return Json(bikeavil, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult Getavil(String CarNum)
        {
            var caravil = (from s in db.CarRegisters where s.CarNum == CarNum select s.Available).FirstOrDefault();
            return Json(caravil, JsonRequestBehavior.AllowGet);
        }




        //[HttpPost]
        //public ActionResult Save(BikeRent rent)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.BikeRents.Add(rent);
        //        var bike = db.BikeRegisters.SingleOrDefault(e => e.BikeNum == rent.BikeId);
        //        if (bike == null)
        //            return HttpNotFound("Bike Number is not valid");
        //        bike.Available = "no";
        //        db.Entry(bike).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(rent);
        //}


        [HttpPost]
        public ActionResult Save(CarRent rent)
        {

            if (ModelState.IsValid)
            {
                db.CarRents.Add(rent);
                var car = db.CarRegisters.SingleOrDefault(e => e.CarNum == rent.CarId);
                if (car == null)
                    return HttpNotFound("Entered car number is Invalid");
                car.Available = "no";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rent);
        }






    }
}
