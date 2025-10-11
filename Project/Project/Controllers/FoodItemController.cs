using BLL.DTOs;
using BLL.Services;
using Project.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/fooditem")]
    public class FoodItemController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = FoodItemService.Get(null); 
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpPost]
        [Route("create")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage Create(FoodItemDTO f)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = FoodItemService.Create(f, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Food item created successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to create food item." });
        }

        [HttpPut]
        [Route("update")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage Update(FoodItemDTO f)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = FoodItemService.Update(f, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Food item updated successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to update food item." });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Logged]
        [RoleLogged("Admin")]
        public HttpResponseMessage Delete(int id)
        {
            var token = Request.Headers.Authorization.Parameter ?? Request.Headers.Authorization.ToString();
            var result = FoodItemService.Delete(id, token);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Food item deleted successfully." });
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed to delete food item." });
        }


        [HttpGet]
        [Route("search")]
        public HttpResponseMessage Search(string name = null, string category = null)
        {
            var data = FoodItemService.Search(name, category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("top")]
        public HttpResponseMessage TopSelling()
        {
            var data = FoodItemService.GetTopSelling();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
