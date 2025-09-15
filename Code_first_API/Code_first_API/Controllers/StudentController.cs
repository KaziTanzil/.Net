using AutoMapper;
using Code_first_API.DTOs;
using Code_first_API.EF;
using Code_first_API.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Code_first_API.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        UMSContext db = new UMSContext();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student,StudentDepartmentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(StudentDTO st)
        {
            
            var data=GetMapper().Map<Student>(st);
            try
            {
                db.Students.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Student Added Successfully");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Student not Added. Invalid Information");
            }

        }

        [HttpGet]
        [Route("StudentList")]
        public HttpResponseMessage StudentList()
        {
            var data = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No student on the table");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
        }
    }
}
