using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/fooditems")]
    public class FoodItemController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get() => Request.CreateResponse(HttpStatusCode.OK, FoodItemService.Get());

        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id) => Request.CreateResponse(HttpStatusCode.OK, FoodItemService.Get(id));

        [HttpGet, Route("search")]
        public HttpResponseMessage Search(string keyword = "", int? categoryId = null, int? restaurantId = null, bool sortAsc = true)
            => Request.CreateResponse(HttpStatusCode.OK, FoodItemService.SearchFilterSort(keyword, categoryId, restaurantId, sortAsc));

        [HttpGet, Route("category/{categoryId:int}")]
        public HttpResponseMessage GetByCategory(int categoryId)
            => Request.CreateResponse(HttpStatusCode.OK, FoodItemService.GetByCategory(categoryId));

        [HttpGet, Route("restaurant/{restaurantId:int}")]
        public HttpResponseMessage GetByRestaurant(int restaurantId)
            => Request.CreateResponse(HttpStatusCode.OK, FoodItemService.GetByRestaurant(restaurantId));

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] FoodItemDTO dto)
        {
            FoodItemService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Food item created successfully");
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] FoodItemDTO dto)
        {
            dto.FoodId = id;
            FoodItemService.Update(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Food item updated successfully");
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            FoodItemService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Food item deleted successfully");
        }
    }
}
