using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameLibray.Models.Dal;
using GameLibray.Models.Entities;

namespace GameLibray.Controllers
{
    public class GCountryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GCountry
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        // GET: GCountry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCountry gCountry = db.Countries.Find(id);
            if (gCountry == null)
            {
                return HttpNotFound();
            }
            return View(gCountry);
        }

        // GET: GCountry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GCountry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName")] GCountry gCountry)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(gCountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gCountry);
        }

        // GET: GCountry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCountry gCountry = db.Countries.Find(id);
            if (gCountry == null)
            {
                return HttpNotFound();
            }
            return View(gCountry);
        }

        // POST: GCountry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName")] GCountry gCountry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gCountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gCountry);
        }

        // GET: GCountry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCountry gCountry = db.Countries.Find(id);
            if (gCountry == null)
            {
                return HttpNotFound();
            }
            return View(gCountry);
        }

        // POST: GCountry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GCountry gCountry = db.Countries.Find(id);
            db.Countries.Remove(gCountry);
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
