using GameLibray.Models.Dal;
using GameLibray.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameLibray.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            List<GCountry>  country= db.Countries.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}