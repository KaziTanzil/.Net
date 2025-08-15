using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Project_Thesis.EF;


namespace Project_Thesis.Controllers
{
    public class LoginController : Controller
    {
        ProjectThisisEntities db = new ProjectThisisEntities();


        // GET: Login
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult login(string gmail, string pass)
        {

                var supervisor = (from s in db.Supervisors
                                  where s.Gmail == gmail && s.Password == pass
                                  select s).SingleOrDefault();
                if (supervisor != null)
                {
                    Session["UserName"] = supervisor.UserName;
                    Session["Gmail"] = supervisor.Gmail;
                    Session["Id"] = supervisor.Id;
                    return RedirectToAction("SupervisorHome", "Supervisor");
                }
                else
                {
                    var student = (from s in db.Students
                                   where s.Gmail == gmail && s.Password == pass
                                   select s).SingleOrDefault();
                    if (student != null)
                    {
                        Session["UserName"] = student.Name;
                        Session["Gmail"] = student.Gmail;
                        Session["Id"] = student.Id;
                        return RedirectToAction("StudentHome", "Student");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid email or password.";
                        return View();
                    }
                }
            }

        }
    }
