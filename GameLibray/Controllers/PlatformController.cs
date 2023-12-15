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
    public class PlatformController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Platform
        public ActionResult Index()
        {
            return View(db.Platforms.ToList());
        }

        // GET: Platform/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlatform gPlatform = db.Platforms.Find(id);
            if (gPlatform == null)
            {
                return HttpNotFound();
            }
            return View(gPlatform);
        }

        // GET: Platform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platform/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlatformId,PlatformName")] GPlatform gPlatform)
        {
            if (ModelState.IsValid)
            {
                db.Platforms.Add(gPlatform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gPlatform);
        }

        // GET: Platform/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlatform gPlatform = db.Platforms.Find(id);
            if (gPlatform == null)
            {
                return HttpNotFound();
            }
            return View(gPlatform);
        }

        // POST: Platform/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlatformId,PlatformName")] GPlatform gPlatform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPlatform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gPlatform);
        }

        // GET: Platform/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPlatform gPlatform = db.Platforms.Find(id);
            if (gPlatform == null)
            {
                return HttpNotFound();
            }
            return View(gPlatform);
        }

        // POST: Platform/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPlatform gPlatform = db.Platforms.Find(id);
            db.Platforms.Remove(gPlatform);
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
