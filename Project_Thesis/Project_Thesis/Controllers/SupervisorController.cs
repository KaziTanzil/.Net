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
        // GET: Supervisor
        public ActionResult SupervisorHome()
        {
            return View(new Supervisor());
        }
    }
}