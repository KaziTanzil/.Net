using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Thesis.EF;

namespace Project_Thesis.Controllers
{
    public class StudentController : Controller
    {
        ProjectThisisEntities db = new ProjectThisisEntities();
       
        // GET: Student
        public ActionResult StudentHome()
        {
            return View(new Student());
        }

        public ActionResult SectionList()
        {
          
                var sections = db.Sections.ToList();
                return View(sections);
            
        }
    }
}