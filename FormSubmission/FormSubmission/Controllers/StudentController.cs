using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        
        public ActionResult Index()
        {
            return View();
        }

       
      


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Form());
        }

        [HttpPost]
        public ActionResult Create(Form form)
        {
            /*if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }*/
            return View(form);
            
        }
    }
}