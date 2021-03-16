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
    public class BikeRegistersController : Controller
    {
        private RentaRidedbEntities2 db = new RentaRidedbEntities2();

        // GET: BikeRegisters
       
        public ActionResult Index()
        {
            return View(db.BikeRegisters.ToList());
        }

        // GET: BikeRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRegister bikeRegister = db.BikeRegisters.Find(id);
            if (bikeRegister == null)
            {
                return HttpNotFound();
            }
            return View(bikeRegister);
        }

        // GET: BikeRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeId,BikeNum,Brand,Model,Available")] BikeRegister bikeRegister)
        {
            if (ModelState.IsValid)
            {
                db.BikeRegisters.Add(bikeRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bikeRegister);
        }

        // GET: BikeRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRegister bikeRegister = db.BikeRegisters.Find(id);
            if (bikeRegister == null)
            {
                return HttpNotFound();
            }
            return View(bikeRegister);
        }

        // POST: BikeRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeId,BikeNum,Brand,Model,Available")] BikeRegister bikeRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bikeRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bikeRegister);
        }

        // GET: BikeRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRegister bikeRegister = db.BikeRegisters.Find(id);
            if (bikeRegister == null)
            {
                return HttpNotFound();
            }
            return View(bikeRegister);
        }

        // POST: BikeRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BikeRegister bikeRegister = db.BikeRegisters.Find(id);
            db.BikeRegisters.Remove(bikeRegister);
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
