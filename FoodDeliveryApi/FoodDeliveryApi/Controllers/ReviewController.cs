using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ReviewService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var data = ReviewService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] ReviewDTO dto)
        {
            ReviewService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Review created successfully");
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] ReviewDTO dto)
        {
            dto.ReviewId = id;
            ReviewService.Update(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Review updated successfully");
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            ReviewService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Review deleted successfully");
        }

        [HttpGet, Route("restaurant/{restaurantId:int}")]
        public HttpResponseMessage GetByRestaurant(int restaurantId)
        {
            var data = ReviewService.GetByRestaurant(restaurantId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
