using Datamanager_Mockup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Datamanager_Mockup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             

            return View();
        }

        public ActionResult Artiklar()
        {

            return View(static_data.builddata());
        }
        public ActionResult Produkter()
        {
            return View();
        }
        public ActionResult Bestallningar()
        {

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