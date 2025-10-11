using BLL.Services;
using Project.Auth;
using Project.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(Login log)
        {
            var res = AuthService.Authenticate(log.Email, log.Password);
            if (res != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Id = res.Id,
                    Key = res.Key,
                    CreatedAt = res.CreatedAt,
                    ExpiredAt = res.ExpiredAt
                });
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Username or password invalid");
        }

        [HttpPost]
        [Route("logout")]
        [Logged]
        public HttpResponseMessage Logout()
        {
            var header = Request.Headers.Authorization;
            var token = header.Scheme == "Bearer" ? header.Parameter : header.ToString();

            if (token != null && AuthService.Logout(token))
                return Request.CreateResponse(HttpStatusCode.OK, "Logged out successfully");

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token");
        }
    }
}
