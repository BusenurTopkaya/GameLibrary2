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
    public class GameController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Game
        public ActionResult Index()
        {

            
            return View(db.Games.ToList());
        }
        
    

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            List<SelectListItem> dgr1 = (from x in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.dgr = dgr1;
            List<SelectListItem> dgr2 = (from x in db.Countries.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CountryName,
                                              Value = x.CountryId.ToString()
                                          }).ToList();
            ViewBag.dgr2 = dgr2;
            List<SelectListItem> dgr3 = (from x in db.Platforms.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PlatformName,
                                              Value = x.PlatformId.ToString()
                                          }).ToList();
            ViewBag.dgr3 = dgr3;
            List<SelectListItem> dgr4 = (from x in db.PlayerAges.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PlayerAge,
                                              Value = x.PlayerAgeId.ToString()
                                          }).ToList();
            ViewBag.dgr4 = dgr4;
            List<SelectListItem> dgr5 = (from x in db.Types.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.TypeName,
                                             Value = x.TypeId.ToString()
                                         }).ToList();
            ViewBag.dgr5 = dgr5;

            return View();
        }


      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game g)
        {
            db.Games.Add(g);
            db.SaveChanges();
           
            
            return RedirectToAction("Index");
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> dgr1 = (from x in db.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.dgr = dgr1;
            List<SelectListItem> dgr2 = (from x in db.Countries.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CountryName,
                                             Value = x.CountryId.ToString()
                                         }).ToList();
            ViewBag.dgr2 = dgr2;
            List<SelectListItem> dgr3 = (from x in db.Platforms.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PlatformName,
                                             Value = x.PlatformId.ToString()
                                         }).ToList();
            ViewBag.dgr3 = dgr3;
            List<SelectListItem> dgr4 = (from x in db.PlayerAges.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PlayerAge,
                                             Value = x.PlayerAgeId.ToString()
                                         }).ToList();
            ViewBag.dgr4 = dgr4;
            List<SelectListItem> dgr5 = (from x in db.Types.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.TypeName,
                                             Value = x.TypeId.ToString()
                                         }).ToList();
            ViewBag.dgr5 = dgr5;
            var gamedgr = db.Games.Find(id);
            return View("Edit",gamedgr);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game g)
        {
            var gme = db.Games.Find(g.GameId);
            gme.GameName = g.GameName;
            gme.GameAbout = g.GameAbout;
            gme.platformId = g.platformId;
            gme.categoryId = g.categoryId;
            gme.CountryId = g.CountryId;
            gme.playerageId = g.playerageId;
            gme.typeId = g.typeId;

            //db.Games.Add(g);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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

