using BLL.DTOs;
using BLL.Services;
using Project.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("all")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage GetAll()
        {

            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = UserService.Get(token);

            if (data == null || data.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "No users found." });

            return Request.CreateResponse(HttpStatusCode.OK, new { message = "Users retrieved successfully.", users = data });
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UserDTO u)
        {
            var resultMessage = UserService.Create(u); 

            if (resultMessage == "User created successfully.")
                return Request.CreateResponse(HttpStatusCode.OK, new { message = resultMessage });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = resultMessage });
        }


        [HttpPut]
        [Route("update")]
        [Logged]
        public HttpResponseMessage Update(UserDTO u)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();

            if (!AuthService.IsAdmin(token) && u.UserId != AuthService.GetUserIdFromToken(token))
                return Request.CreateResponse(HttpStatusCode.Forbidden, new { message = "You are not allowed to update this user." });

            var result = UserService.Update(u, token);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User updated successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to update user." });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage Delete(int id)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = UserService.Delete(id, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User deleted successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to delete user." });
        }
    }
}
