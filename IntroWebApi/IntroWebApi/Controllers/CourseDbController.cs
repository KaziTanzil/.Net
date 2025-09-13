using IntroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroWebApi.Controllers
{
    [RoutePrefix("api/CourseDb")]
    public class CourseDbController : ApiController
    {
        [HttpGet]
        public List<Cource> Get()
        {

            RegistrationEntities db = new RegistrationEntities();
            var data = new List<Cource>();
            foreach(var c in db.Cources)
            {
                var course = new Cource()
                {
                    CId = c.CId,
                    CName=c.CName,
                    TCapacity=c.TCapacity,
                    Count=c.Count
                };

                data.Add(course);
                
            }
            return data;
        }

        [HttpGet]
        [Route("GetName")]
        public List<String> GetName()
        {
            RegistrationEntities db = new RegistrationEntities();
            var name = (from c in db.Cources select c.CName).ToList();
            return name;
        }
    }
}
