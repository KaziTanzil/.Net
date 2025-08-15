using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task2_Value_passing.Controllers
{
    public class StudentController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult Create()
        {
            String name = Request["Name"];
            String id = Request["Id"];
            String Email = Request["Email"];
            String Address = Request["Address"];
            return View();
        }
    }
}