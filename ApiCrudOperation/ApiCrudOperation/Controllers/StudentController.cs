using ApiCrudOperation.DTOs;
using ApiCrudOperation.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCrudOperation.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        TanzilEntities db=new TanzilEntities();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDeptDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public HttpResponseMessage Get()
        {
            var d = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
            
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            var data = GetMapper().Map<Student>(s);
            try
            {
                db.Students.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Incomplete");
            }
        }


        [HttpGet]
        [Route("StudentList/{id}")]
        
        public HttpResponseMessage StudentList(int id)
        {
            try
            {
                var dept = db.Departments.Find(id);

                if (dept == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Department not found");
                }

                // Map Department entity into DepartmentStudentDTO
                var data = GetMapper().Map<DepartmentStudentDTO>(dept);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Fuck");
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var d =db.Students.Find(id);
            if(d == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }

            try
            {
                db.Students.Remove(d);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.NotFound, "Successfully deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }



    }
}
