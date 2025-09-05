using SportsRegistration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsRegistration.Controllers
{
    public class AdminController : Controller
    {
        SportsEntities db = new SportsEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewRegistrations()
        {
            var registrations = db.Registrations.ToList();
            return View(registrations);
        }

        [HttpPost]
        public ActionResult ViewRegistrations(string studentId, string sId, string actionType)
        {
            int sid = Convert.ToInt32(studentId);
            int sportId = Convert.ToInt32(sId);

            var registration = (from r in db.Registrations
                                where r.StudentId == sid && r.SId == sportId
                                select r).FirstOrDefault();

            if (registration == null)
            {
                TempData["Message"] = "Registration not found.";
                return RedirectToAction("ViewRegistrations");
            }

            if (actionType == "confirm")
            {
                registration.Status = "Approved";
                TempData["Message"] = "Registration approved successfully.";
            }
            else if (actionType == "cancel")
            {
                registration.Status = "Dropped";
                TempData["Message"] = "Registration cancelled.";
                var Sport = (from sp in db.Sports
                             where sp.SId == sportId
                             select sp).FirstOrDefault();
                Sport.Count--;
               
            }

            db.SaveChanges();

            return RedirectToAction("ViewRegistrations");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Sport());
        }
        [HttpPost]
        public ActionResult Create(string sports_name)
        {
            var existingSports = (from s in db.Sports
                                  where s.SName == sports_name
                                  select s).FirstOrDefault();
            if (existingSports == null)
            {
                Sport c = new Sport();
                c.SName = sports_name;

                c.Count = 0;
                c.Capacity = 20;
                db.Sports.Add(c);
                db.SaveChanges();
                TempData["Message"] = "Section Added Successfully";
                return RedirectToAction("Create");
            }
            else
            {
                TempData["Message"] = $"Sport section named-> {sports_name} Already Exists";
                return RedirectToAction("Create");
            }
        }
    }
}