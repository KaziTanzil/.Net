using SportsRegistration.EF;
using System;
using SportsRegistration.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsRegistration.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        SportsEntities db = new SportsEntities();
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Admin, AdminDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string gmail, string password)
        {
            var s = (from m in db.Students where m.Gmail == gmail && m.Password == password select m).SingleOrDefault();
            var st = GetMapper().Map<Student, StudentDTO>(s);
            var admin = (from a in db.Admins where a.AGmail == gmail && a.APassword == password select a).SingleOrDefault();
            var ad = GetMapper().Map<Admin, AdminDTO>(admin);
            if (ad != null)
            {
                Session["admin"] = admin;
                Session["AdminId"] = admin.AId.ToString();
                Session["AdminName"] = admin.AName.ToString();
                return RedirectToAction("Index", "Admin");
            }
            if (st != null)
            {
                Session["user"] = st;
                Session["StudentId"] = st.StudentId.ToString();
                Session["StudentName"] = st.StudentName.ToString();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                TempData["Msg"] = "Invalid Gmail or Password";
            }
            return View();
        }
    }
}