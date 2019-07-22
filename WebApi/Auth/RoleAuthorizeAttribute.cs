using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Auth
{
    public class RoleAuthorizeAttribute:AuthorizeAttribute
    {
        protected override bool IsAuthorized (HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }

        protected override void HandleUnauthorizedRequest (HttpActionContext actionContext)
        {
            actionContext.Response =
               actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"Unauthorized");
        }
    }
}