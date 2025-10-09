using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/deliveries")]
    public class DeliveryController : ApiController
    {
        [HttpGet, Route("{id:int}")]
        public DeliveryDTO Get(int id) => DeliveryService.Get(id);

        [HttpPost, Route("")]
        public void Create([FromBody] DeliveryDTO dto) => DeliveryService.Create(dto);

        [HttpPut, Route("{id:int}/status")]
        public void UpdateStatus(int id, [FromBody] string status) => DeliveryService.UpdateStatus(id, status);


    }
}

