using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rent_a_ride;

namespace Rent_a_ride.Controllers
{
    public class CarRegistersController : Controller
    {
        private RentaRidedbEntities2 db = new RentaRidedbEntities2();

        // GET: CarRegisters
        public ActionResult Index()
        {

            return View(db.CarRegisters.ToList());
        }

        // GET: CarRegisters/Details/5
        public ActionResult Details(int? id)
        {


            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            //Session["UserID"] = u.UserID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
               CarRegister carRegister = db.CarRegisters.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }

        // GET: CarRegisters/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: CarRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,CarNum,Brand,Model,Available")] CarRegister carRegister)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                db.CarRegisters.Add(carRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carRegister);
        }

        // GET: CarRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRegister carRegister = db.CarRegisters.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }

        // POST: CarRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,CarNum,Brand,Model,Available")] CarRegister carRegister)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(carRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carRegister);
        }

        // GET: CarRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRegister carRegister = db.CarRegisters.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }

        // POST: CarRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            CarRegister carRegister = db.CarRegisters.Find(id);
            db.CarRegisters.Remove(carRegister);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
