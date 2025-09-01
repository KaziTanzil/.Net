using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class AdminController : Controller
    {
        RegistrationEntities1 db = new RegistrationEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Cource());
        }
        [HttpPost]
        public ActionResult Create(string course_credit, string course_name)
        {
            var existingCourse = (from co in db.Cources
                                  where co.CName == course_name
                                  select co).FirstOrDefault();
            if (existingCourse == null)
            {
                Cource c = new Cource();
                c.CName = course_name;
                c.Credit = course_credit;
                c.Count = 0;
                c.TCapacity = 40;
                db.Cources.Add(c);
                db.SaveChanges();
                TempData["Message"] = "Course Added Successfully";
                return RedirectToAction("Create");
            }
            else
            {
                TempData["Message"] = $"Course {course_name} Already Exists";
                return RedirectToAction("Create");
            }

        }
    }
}