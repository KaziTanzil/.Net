using BLL.DTOs;
using BLL.Services;
using Project.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Project.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("all")]
        [Logged]
        public HttpResponseMessage GetAll()
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = OrderService.Get(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        [Logged]
        [RoleLogged("Customer")]
        public HttpResponseMessage Create(OrderDTO o)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = OrderService.Create(o, token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("history")]
        [Logged]
        public HttpResponseMessage History()
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var data = OrderService.GetHistory(token);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("updatestatus")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage UpdateStatus(UpdateOrderStatusDTO dto)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = OrderService.UpdateStatus(dto.OrderId, dto.Status, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Order status updated successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to update order status." });
        }


    }
}
