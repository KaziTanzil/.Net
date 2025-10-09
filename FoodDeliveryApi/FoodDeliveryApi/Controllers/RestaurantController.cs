using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/restaurants")]
    public class RestaurantController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var data = RestaurantService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var data = RestaurantService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet, Route("search")]
        public HttpResponseMessage Search(string keyword = "", double? minRating = null, bool sortAsc = true)
        {
            var data = RestaurantService.SearchFilterSort(keyword, minRating, sortAsc);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] RestaurantDTO dto)
        {
            RestaurantService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Restaurant created successfully");
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] RestaurantDTO dto)
        {
            dto.RestaurantId = id;
            RestaurantService.Update(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Restaurant updated successfully");
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            RestaurantService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Restaurant deleted successfully");
        }
    }
}
