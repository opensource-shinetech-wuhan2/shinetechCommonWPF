using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Business.Model;
using Newtonsoft.Json;

namespace WebApi.Auth
{
    public class TokenAuthorizeAttribute :AuthorizeAttribute
    {
        public override void OnAuthorization (HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest (HttpActionContext actionContext)
        {                          
            base.HandleUnauthorizedRequest(actionContext);

            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();

            if(response.StatusCode != HttpStatusCode.OK)
            {                
                var content = new ViewResultBase
                {
                    Message = response.StatusCode.ToString(),
                    Status = Convert.ToInt32(response.StatusCode)
                };
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(JsonConvert.SerializeObject(content),Encoding.UTF8,"application/json");
            }
        }

        protected override bool IsAuthorized (HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}