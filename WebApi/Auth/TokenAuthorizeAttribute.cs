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
using System.Security.Claims;
using Business.IBusiness;
using Unity.Attributes;

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
            var context = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = context.Request.Headers["Authorization"];
            if(!string.IsNullOrEmpty(token))
            {
                string userName = string.Empty;
                ClaimsIdentity identity = context.User.Identity as ClaimsIdentity;
                var claim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                if(claim != null)
                {
                    userName = claim.Value;
                }

                if(!string.IsNullOrEmpty(userName))
                {
                    //TODO: get user permissions
                    var permissionBusiness =  GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IPermissionBusiness)) as IPermissionBusiness;
                    var userPermissionResult = permissionBusiness.GetUserPermissions(userName);
                    List<string> userPermissions = new List<string>();
                    foreach(var permission in userPermissionResult)
                    {
                        userPermissions.Add(permission.Name);
                    }

                    var intersect = userPermissions.Intersect(Permissions);
                    var authorized = RequireAllPermissions ? (intersect.Count() == Permissions.Count()) : intersect.Count() > 0;
                    if(authorized)
                    {
                        base.IsAuthorized(actionContext);
                    }
                    else
                    {
                        HandleUnauthorizedRequest(actionContext);
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