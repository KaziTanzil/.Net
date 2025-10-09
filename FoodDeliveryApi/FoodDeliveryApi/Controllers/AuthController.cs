using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserDTO user)
        {
            var data = AuthService.Register(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            var data = AuthService.Login(login.Email, login.Password);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
