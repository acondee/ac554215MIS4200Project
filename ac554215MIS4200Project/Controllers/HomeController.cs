using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ac554215MIS4200Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "MIS4200 site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me";

            return View();
        }
    }
}