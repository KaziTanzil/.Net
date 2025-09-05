using SportsRegistration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsRegistration.Controllers
{
    public class StudentController : Controller
    {
        SportsEntities db = new SportsEntities();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MySection()
        {
            int sid = Convert.ToInt32(Session["StudentId"]);
            var registrations = (from r in db.Registrations
                                 where r.StudentId == sid
                                 select r).ToList();
            if (registrations == null || registrations.Count == 0)
            {
                TempData["Message"] = "No registrations found.";
                return RedirectToAction("Index");
            }
            return View(registrations);

        }
           
    }
}