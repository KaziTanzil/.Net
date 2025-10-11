using BLL.DTOs;
using BLL.Services;
using Project.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("all")]
        [Logged]
        public HttpResponseMessage GetAll()
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = PaymentService.Get(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        [Logged]
        [RoleLogged("Customer")]
        public HttpResponseMessage Create(PaymentDTO p)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = PaymentService.Create(p, token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
