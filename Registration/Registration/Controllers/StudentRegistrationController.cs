using AutoMapper;
using Registration.DTOs;
using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class SRegistrationController : Controller
    {
        RegistrationEntities1 db = new RegistrationEntities1();
        // GET: Registration

        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Cource, CourseDTO>().ReverseMap();
                cfg.CreateMap<SRegistration, RegistrationDTO>().ReverseMap();

            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var c = db.Cources.ToList();
            return View(c);
        }
        [HttpPost]
        public ActionResult Register(string[] courses)
        {
            if (courses == null || courses.Length == 0)
            {
                TempData["Message"] = "Please select at least one course.";
                return RedirectToAction("Register");
            }

            if (TempData["Message"] == null)
            {
                TempData["Message"] = "";
            }

            int sid = Convert.ToInt32(Session["StudentId"]);

            foreach (var c in courses)
            {
                int courseId = Convert.ToInt32(c);

                var course = (from cr in db.Cources
                              where cr.CId == courseId
                              select cr).SingleOrDefault();
                if (course == null)
                {
                    TempData["Message"] += $"Course with ID {courseId} not found.";
                    continue;
                }

                if (course.Count >= course.TCapacity)
                {
                    TempData["Message"] += $"Course '{course.CName}' is already full.";
                    continue;
                }

                bool alreadyRegistered = (from re in db.SRegistrations
                                          where re.SId == sid && re.CId == courseId
                                          select re).Any();
                if (alreadyRegistered)
                {
                    TempData["Message"] += $"You are already registered for '{course.CName}'.";
                    continue;
                }

                SRegistration r = new SRegistration
                {
                    SId = sid,
                    CId = courseId
                };

                db.SRegistrations.Add(r);
                course.Count++;
                db.SaveChanges();
            }


            if (string.IsNullOrEmpty(TempData["Message"].ToString()))
            {
                TempData["Message"] = "Courses registered successfully.";
            }
            return RedirectToAction("Register");
        }





    }
}