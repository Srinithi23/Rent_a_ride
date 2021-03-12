using System;
using System.Collections.Generic;
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
            return View();
        }


        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.CarRegisters.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.Customers where s.CustomerId == id select s.CustomerName).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavailability(String CarNum)
        {
            var caravailbty = (from s in db.CarRegisters where s.CarNum == CarNum select s.Available).FirstOrDefault();
            return Json(caravailbty, JsonRequestBehavior.AllowGet);
        }
    }
}