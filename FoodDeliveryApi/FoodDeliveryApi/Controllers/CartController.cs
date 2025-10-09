using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/carts")]
    public class CartController : ApiController
    {
        [HttpGet, Route("{userId:int}")]
        public List<CartDTO> GetByUser(int userId) => CartService.GetByUser(userId);

        [HttpPost, Route("{cartId:int}/items")]
        public void AddItem(int cartId, [FromBody] CartItemDTO dto) => CartService.AddItem(cartId, dto);

        [HttpDelete, Route("items/{cartItemId:int}")]
        public void RemoveItem(int cartItemId) => CartService.RemoveItem(cartItemId);

        [HttpGet, Route("{cartId:int}/total")]
        public decimal GetTotal(int cartId) => CartService.GetCartTotal(cartId);
    }
}
