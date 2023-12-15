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
    public class GTypesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GTypes
        public ActionResult Index()
        {
            return View(db.Types.ToList());
        }

        // GET: GTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GType gType = db.Types.Find(id);
            if (gType == null)
            {
                return HttpNotFound();
            }
            return View(gType);
        }

        // GET: GTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TypeName")] GType gType)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(gType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gType);
        }

        // GET: GTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GType gType = db.Types.Find(id);
            if (gType == null)
            {
                return HttpNotFound();
            }
            return View(gType);
        }

        // POST: GTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TypeName")] GType gType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gType);
        }

        // GET: GTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GType gType = db.Types.Find(id);
            if (gType == null)
            {
                return HttpNotFound();
            }
            return View(gType);
        }

        // POST: GTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GType gType = db.Types.Find(id);
            db.Types.Remove(gType);
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
