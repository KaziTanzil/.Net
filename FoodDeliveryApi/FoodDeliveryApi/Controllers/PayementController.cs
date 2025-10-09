using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentController : ApiController
    {
        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PaymentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] PaymentDTO dto)
        {
            PaymentService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Payment created successfully");
        }

        [HttpPut, Route("{id:int}/status")]
        public HttpResponseMessage UpdateStatus(int id, [FromBody] string status)
        {
            PaymentService.UpdateStatus(id, status);
            return Request.CreateResponse(HttpStatusCode.OK, "Payment status updated successfully");
        }

        [HttpGet, Route("status/{status}")]
        public HttpResponseMessage GetByStatus(string status)
        {
            var data = PaymentService.GetByStatus(status);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
