using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Project.Auth
{
    public class Logged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;

            if (header == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    "No token supplied"
                );
                return;
            }


            var token = header.Scheme == "Bearer" ? header.Parameter : header.ToString();

            if (!AuthService.IsTokenValid(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    "Supplied token is invalid or expired"
                );
                return;
            }

            base.OnAuthorization(actionContext);
        }
    }

}