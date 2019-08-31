using GymBooker1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymBooker1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.GymClasses = db.GymClasses.ToList();

            ViewBag.cardioDesc = "Get fitter and burn calories. These classes are for anyone that loves music and energy.";
            ViewBag.toneDesc = "Change the shape of your body by strengthening and conditioning your muscles.";
            ViewBag.mindBodyDesc = "All rounder classes for wellbeing, core strength, flexibility and low impact conditioning.";
            ViewBag.strengthDesc = "Feel stronger and fitter using functional kit such as battle ropes, assault bikes and kettlebells.";

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