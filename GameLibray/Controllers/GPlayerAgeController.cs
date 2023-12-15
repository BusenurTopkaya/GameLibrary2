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
    public class GPlayerAgeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GPlayerAge
        public ActionResult Index()
        {
            return View(db.PlayerAges.ToList());
        }

        // GET: GPlayerAge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlayerAge gPlayerAge = db.PlayerAges.Find(id);
            if (gPlayerAge == null)
            {
                return HttpNotFound();
            }
            return View(gPlayerAge);
        }

        // GET: GPlayerAge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPlayerAge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerAgeId,PlayerAge")] GPlayerAge gPlayerAge)
        {
            if (ModelState.IsValid)
            {
                db.PlayerAges.Add(gPlayerAge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gPlayerAge);
        }

        // GET: GPlayerAge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlayerAge gPlayerAge = db.PlayerAges.Find(id);
            if (gPlayerAge == null)
            {
                return HttpNotFound();
            }
            return View(gPlayerAge);
        }

        // POST: GPlayerAge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerAgeId,PlayerAge")] GPlayerAge gPlayerAge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPlayerAge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gPlayerAge);
        }

        // GET: GPlayerAge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlayerAge gPlayerAge = db.PlayerAges.Find(id);
            if (gPlayerAge == null)
            {
                return HttpNotFound();
            }
            return View(gPlayerAge);
        }

        // POST: GPlayerAge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPlayerAge gPlayerAge = db.PlayerAges.Find(id);
            db.PlayerAges.Remove(gPlayerAge);
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
