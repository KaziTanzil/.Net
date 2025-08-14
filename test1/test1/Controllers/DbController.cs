using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.EF; // Ensure this namespace matches your project structure 

namespace test1.Controllers
{
    public class DbController : Controller
    {
        // GET: Db
        TawEntities db = new TawEntities();


        public ActionResult TableList()
        { 
            var data=db.Tawtables.ToList();
            return View(data);
        }
       
           
        

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Tawtable());
        }

        [HttpPost]
        public ActionResult Index(Tawtable s)
        {
            if (s != null)
            {
                db.Tawtables.Add(s);
                db.SaveChanges();
            }

            return View(s);
        }
    }
}