using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        [HttpGet, Route("{id:int}")]
        public OrderDTO Get(int id) => OrderService.Get(id);

        [HttpGet, Route("")]
        public List<OrderDTO> Get() => OrderService.Get();

        [HttpPost, Route("")]
        public void Create([FromBody] OrderDTO dto) => OrderService.Create(dto);

        [HttpPut, Route("{id:int}")]
        public void Update(int id, [FromBody] OrderDTO dto)
        {
            dto.OrderId = id;
            OrderService.Update(dto);
        }

        [HttpDelete, Route("{id:int}")]
        public void Delete(int id) => OrderService.Delete(id);

        [HttpGet, Route("user/{userId:int}")]
        public List<OrderDTO> GetByUser(int userId) => OrderService.GetByUser(userId);
    }
}
