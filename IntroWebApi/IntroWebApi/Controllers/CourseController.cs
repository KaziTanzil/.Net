using IntroWebApi.Models;
using IntroWebApi.Models.vM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroWebApi.Controllers
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        //by default api maps method with request verbs
        public List<CourseModel> Get()
        {
            List<CourseModel> course=new List<CourseModel>();
            for (int i = 0; i < 10; i++)
            {
                course.Add(new CourseModel { Id = i + 1, Name = "Course" + i });
            }
            return course;
            //RegistrationEntities db = new RegistrationEntities();
            //return db.Cources.ToList();
        }


        public IHttpActionResult Get(int id)
        {
           
            return Ok("Hello from Tanzil "+id);
        }


        public Message Post()
        {
            Message m = new Message();
 
            m.Msg = "Hello";
            return m;
        }


        [HttpPost]
        [Route("PostData")]
        public string PostData(CourseModel c)
        {
            List<CourseModel> course = new List<CourseModel>();
            for (int i = 0; i < 10; i++)
            {
                course.Add(new CourseModel { Id = i + 1, Name = "Course" + i });
            }
            course.Add(c);
            return "Course Added Successfully. "+c.Id+" "+c.Name;
        }

        [HttpPost]
        [Route("PostHi")]
        public IHttpActionResult PostHi()
        {
            var m = "Fuck you";
            return Ok(m);
        }
        [HttpPost]
        [Route("PostBye")]
        public HttpResponseMessage PostBye()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Fuck you too");
        }

        [HttpPut]
        public HttpResponseMessage Put()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Put my Dick into your hole");
        }

        [HttpDelete]
        public string Delete()
        {
            return "Delete";
        }


    }
}
