using CrudOperation.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        TanzilEntities dbObj = new TanzilEntities();
        public ActionResult Student()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
                       return View(new student());
        }

        [HttpPost]
        public ActionResult AddStudent(student s)
        {
            if (ModelState.IsValid) {
                student obj = new student();
                obj.Name = s.Name;
                obj.Fname = s.Fname;
                obj.Email = s.Email;
                obj.Mobile = s.Mobile;
                obj.Description = s.Description;

                dbObj.student.Add(obj);
                dbObj.SaveChanges();

                return RedirectToAction("Student");
            }

                return View(s);
            }

        public ActionResult StudentList()
        {
            var studentList = dbObj.student.ToList();
            return View(studentList);

        }



        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = (from s in dbObj.student
                           where s.ID == id
                           select s).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(student s)
        {
            if (ModelState.IsValid)
            {
                var existing = (from st in dbObj.student
                                where st.ID == s.ID
                                select st).FirstOrDefault();
                if (existing != null)
                {
                    existing.Name = s.Name;
                    existing.Fname = s.Fname;
                    existing.Email = s.Email;
                    existing.Mobile = s.Mobile;
                    existing.Description = s.Description;

                    dbObj.SaveChanges();
                }
                return RedirectToAction("StudentList");
            }
            return View(s);
        }




        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = (from s in dbObj.student
                           where s.ID == id
                           select s).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student); // Shows DeleteStudent.cshtml
        }

        [HttpPost]
        public ActionResult DeleteStudent(student s)
        {
            var studentToDelete = (from st in dbObj.student
                                   where st.ID == s.ID
                                   select st).FirstOrDefault();

            if (studentToDelete != null)
            {
                dbObj.student.Remove(studentToDelete);
                dbObj.SaveChanges();
            }

            return RedirectToAction("StudentList");
        }


    }
}