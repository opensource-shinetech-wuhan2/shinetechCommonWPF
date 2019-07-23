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
using Common.BearerToken;
using Newtonsoft.Json;

namespace WebApi.Auth
{
    public class TokenAuthorizeAttribute :AuthorizeAttribute
    {
        public string[] Permissions { get; set; }

        public bool RequireAllPermissions { get; set; }

        public TokenAuthorizeAttribute (params string[] permissions)
        {
            Permissions = permissions;
        }

        public override void OnAuthorization (HttpActionContext actionContext)
        {
            var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = content.Request.Headers["Authorization"];
            if(!string.IsNullOrEmpty(token))
            {
                var desToken = DataProtector.Create().Unprotect(token.Remove(0,7));//bearer (token)
                string userName;
                desToken.Properties.Dictionary.TryGetValue("userName",out userName);
                if(!string.IsNullOrEmpty(userName))
                {
                    //TODO: get permissions from permission dictionary
                    string[] userPermissions = { "canViewMenu" };
                    var intersect = userPermissions.Intersect(Permissions);
                    if(intersect.Count() > 0)
                    {
                        base.IsAuthorized(actionContext);
                    }
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if(isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest (HttpActionContext actionContext)
        {                          
            base.HandleUnauthorizedRequest(actionContext);
            
            //var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();

            //if(response.StatusCode != HttpStatusCode.OK)
            //{                
            //    var content = new ViewResultBase
            //    {
            //        Message = response.StatusCode.ToString(),
            //        Status = Convert.ToInt32(response.StatusCode)
            //    };
            //    response.StatusCode = HttpStatusCode.OK;
            //    response.Content = new StringContent(JsonConvert.SerializeObject(content),Encoding.UTF8,"application/json");
            //}
        }

        protected override bool IsAuthorized (HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}