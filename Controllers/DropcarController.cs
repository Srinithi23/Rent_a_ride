using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_ride.Controllers
{
    public class DropcarController : Controller
    {
        RentaRidedbEntities2 db = new RentaRidedbEntities2();
        // GET: dropbike
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Droppedcar()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Save4(Dropcar recar)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Dropcars.Add(recar);
        //        var car = db.CarRegisters.SingleOrDefault(e => e.CarNum == recar.CarNumber);
        //        if (car == null)
        //            return HttpNotFound("Bike number not found");
        //        car.Available = "yes";
        //        db.Entry(car).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }



        //    return View(recar);
        //}

        [HttpPost]
        public ActionResult Save(Dropcar recar)
        {
            if (ModelState.IsValid)
            {
                db.Dropcars.Add(recar);
                var car = db.CarRegisters.SingleOrDefault(e => e.CarNum == recar.CarNumber);
                if (car == null)
                    return HttpNotFound("Car Number is not valid");
                car.Available = "yes";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recar);
        }






        [HttpPost]

        public ActionResult Getid(string CarNumber)
        {
            var carN = (from s in db.CarRents
                         where s.CarId == CarNumber
                         select new
                         {
                             Start_Date = s.StartDate,
                             End_Date = s.EndDate,
                             Cusid = s.CustomerId,
                             Carnum = s.CarId,
                             Fee_ = s.Fee,
                             ElapsedDays = SqlFunctions.DateDiff("day", s.EndDate, DateTime.Now)
                         }).ToArray();

            return Json(carN, JsonRequestBehavior.AllowGet);
        }



    }
}