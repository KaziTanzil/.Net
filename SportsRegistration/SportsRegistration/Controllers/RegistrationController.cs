using AutoMapper;
using SportsRegistration.EF;
using SportsRegistration.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
         SportsEntities db = new SportsEntities();

        // GET: Registration

        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<Sport, SportsDTO>().ReverseMap();
                

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
            var c = db.Sports.ToList();
            return View(c);
        }
        [HttpPost]
        public ActionResult Register(string[] sports)
        {
            if (sports == null || sports.Length == 0)
            {
                TempData["Message"] = "Please select at least one Sport.";
                return RedirectToAction("Register");
            }

            if (TempData["Message"] == null)
            {
                TempData["Message"] = "";
            }

            int sid = Convert.ToInt32(Session["StudentId"]);
            int existingRegistrations = (from r in db.Registrations
                                         where r.StudentId == sid
                                         select r).Count(); 

            
            if (existingRegistrations + sports.Length > 2)
            {
                TempData["Message"] = "You can apply for a maximum of 2 sport sections.";
                return RedirectToAction("Register");
            }

            foreach (var c in sports)
            {
                int SportsId = Convert.ToInt32(c);

                var sport = (from sp in db.Sports
                              where sp.SId == SportsId
                              select sp).SingleOrDefault();
                if (sport == null)
                {
                    TempData["Message"] += $"Sport Section with ID {SportsId} not found.";
                    continue;
                }

                if (sport.Count >= sport.Capacity)
                {
                    TempData["Message"] += $"Sport section '{sport.SName}' is already full.";
                    continue;
                }

                bool alreadyRegistered = (from re in db.Registrations
                                          where re.StudentId == sid && re.SId == SportsId
                                          select re).Any();
                if (alreadyRegistered)
                {
                    TempData["Message"] += $"You are already applied for '{sport.SName}'.";
                    continue;
                }

                Registration r = new Registration
                {
                    StudentId = sid,
                    SId = SportsId,
                    Status="Applied"
                };

                db.Registrations.Add(r);
                sport.Count++;
                db.SaveChanges();
            }


            if (string.IsNullOrEmpty(TempData["Message"].ToString()))
            {
                TempData["Message"] = "Sports section Applied successfully.";
            }
            return RedirectToAction("Register");
        }
    }
}