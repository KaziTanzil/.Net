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
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        UMSContext db=new UMSContext();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department,DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department,DepartmentStudentDTO>().ReverseMap();
                cfg.CreateMap<Department,DepartmentTeacherDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public HttpResponseMessage CreateDepartment(DepartmentDTO d)
        {
            var data=GetMapper().Map<Department>(d);

            try
            {
                db.Departments.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Department Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong info");
            }
        }

        [HttpGet]
        [Route("DepartmentList")]
        public HttpResponseMessage DepartmentList()
        {
            var data = GetMapper().Map<List<DepartmentDTO>>(db.Departments.ToList());
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No Departments on the table");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }
    }
}
