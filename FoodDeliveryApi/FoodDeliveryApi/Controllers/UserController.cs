using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] UserDTO dto)
        {
            UserService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "User created successfully");
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] UserDTO dto)
        {
            dto.UserId = id;
            UserService.Update(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "User updated successfully");
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully");
        }

        [HttpGet, Route("role/{role}")]
        public HttpResponseMessage GetByRole(string role)
        {
            var data = UserService.GetByRole(role);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
