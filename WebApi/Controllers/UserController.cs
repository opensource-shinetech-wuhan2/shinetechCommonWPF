using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Business.Model;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController :ApiController
    {
        private static AuthenticationProperties CreateProperties (string userName)
        {
            var data = new Dictionary<string,string>
            {
                { "userName", userName}
            };
            return new AuthenticationProperties(data);
        }

        [HttpPost]
        [Route("login")]
        public ViewResult<string> Login (JObject parameters)
        {
            var result = new ViewResult<string>();

            var username = parameters["Username"].ToString();
            var pwd = parameters["Pwd"].ToString();
            if(username == "admin" && pwd == "admin")
            {
                var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
                var ticket = new AuthenticationTicket(identity,CreateProperties(username));
                ticket.Properties.IssuedUtc = DateTime.UtcNow;
                ticket.Properties.ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

                var token = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
                result.Data = token;
                result.Status = 0;
            }
            return result;
        }
    }
}
