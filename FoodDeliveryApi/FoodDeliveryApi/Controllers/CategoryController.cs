using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliverySystem.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get() => Request.CreateResponse(HttpStatusCode.OK, CategoryService.Get());

        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get(int id) => Request.CreateResponse(HttpStatusCode.OK, CategoryService.Get(id));

        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody] CategoryDTO dto)
        {
            CategoryService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Category created successfully");
        }

        [HttpPut, Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody] CategoryDTO dto)
        {
            dto.CategoryId = id;
            CategoryService.Update(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Category updated successfully");
        }

        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            CategoryService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Category deleted successfully");
        }
    }
}
