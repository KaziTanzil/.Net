using BLL.DTOs;
using BLL.Services;
using Project.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Project.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        [HttpGet]
        [Route("all")]
        [Logged]
        [RoleLogged("Customer")]
        public HttpResponseMessage GetAll()
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = CartService.Get(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("add")]
        [Logged]
        [RoleLogged("Customer")]
        public HttpResponseMessage Add(CartDTO c)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = CartService.Add(c, token);
            if (data)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Cart Created successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to create Cart" });
        }


        [HttpDelete]
        [Route("remove/{id}")]
        [Logged]
        [RoleLogged("Customer")]
        public HttpResponseMessage Remove(int id)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = CartService.Remove(id, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Cart item removed successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to remove cart item." });
        }

            [HttpGet]
            [Route("total")]
            [Logged]
            [RoleLogged("Customer")]
            public HttpResponseMessage Total()
            {
                var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
                var total = CartService.GetTotalPrice(token);
                return Request.CreateResponse(HttpStatusCode.OK, new { totalPrice = total });
            }
        }
}
