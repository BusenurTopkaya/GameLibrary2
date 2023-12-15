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
    public class CatagoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Catagory
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Catagory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCatagory gCatagory = db.Categories.Find(id);
            if (gCatagory == null)
            {
                return HttpNotFound();
            }
            return View(gCatagory);
        }

        // GET: Catagory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] GCatagory gCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(gCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gCatagory);
        }

        // GET: Catagory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCatagory gCatagory = db.Categories.Find(id);
            if (gCatagory == null)
            {
                return HttpNotFound();
            }
            return View(gCatagory);
        }

        // POST: Catagory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] GCatagory gCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gCatagory);
        }

        // GET: Catagory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GCatagory gCatagory = db.Categories.Find(id);
            if (gCatagory == null)
            {
                return HttpNotFound();
            }
            return View(gCatagory);
        }

        // POST: Catagory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GCatagory gCatagory = db.Categories.Find(id);
            db.Categories.Remove(gCatagory);
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
