using coachingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coachingSystem.Controllers
{
    
    public class HomeController : Controller
    {

        private cmsEntities db = new cmsEntities();

        facultyimageshow model = new facultyimageshow();
        public ActionResult Index()
        {


            return View(db.tbl_faculty_details.ToList());
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
        public ActionResult FeeStructure()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            return View();

        }
    }
}