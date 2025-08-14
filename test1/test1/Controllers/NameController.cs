using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models; // Ensure this namespace matches your project structure

namespace test1.Controllers
{
    public class NameController : Controller
    {


        [HttpGet]
        public ActionResult Create()
        {
            return View(new From());
        }
        [HttpPost]
        public ActionResult Create(From s)
        {
         return View(s);


        }
    }
}