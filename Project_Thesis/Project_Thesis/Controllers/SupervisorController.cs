using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Thesis.EF;

namespace Project_Thesis.Controllers
{
    public class SupervisorController : Controller
    {
        ProjectThisisEntities db = new ProjectThisisEntities();
        // GET: Supervisor
        public ActionResult SupervisorHome()
        {
            return View(new Supervisor());
        }

        [HttpGet]
        public ActionResult CreateSection()
        {
            return View(new Section());
        }   
        [HttpPost]
        public ActionResult CreateSection(Section section)
        {
            
                Section obj = new Section();
                obj.Id = (int)Session["Id"];
                obj.Supervisor = (string)Session["UserName"];
                obj.SectionName =section.SectionName; 
                obj.Topic = section.Topic;

                db.Sections.Add(obj);
                db.SaveChanges();
                return RedirectToAction("SupervisorHome");
            
        }
    }
}