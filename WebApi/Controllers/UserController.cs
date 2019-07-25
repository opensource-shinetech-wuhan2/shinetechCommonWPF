using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Business.IBusiness;
using Business.Model;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController :ApiController
    {
        IUserBusiness _userBusiness;
        IPermissionBusiness _permissionBusiness;
        public UserController (IUserBusiness userBusiness,
            IPermissionBusiness permissionBusiness
            )
        {
            _userBusiness = userBusiness;
            _permissionBusiness = permissionBusiness;
        }

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
        public async Task<LoginViewResult> Login (JObject parameters)
        {
            var result = new LoginViewResult();
            var username = parameters["Username"].ToString();
            var pwd = parameters["Pwd"].ToString();

            var user = _userBusiness.GetUserByName("admin");
            if(user != null && user.Password == pwd)
            {
                var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);

                var permissions = await _permissionBusiness.GetUserPermissions(1);

                //role
                foreach(var userRole in user.UserRoles)
                {
                    var roleName = userRole.Role.Name;
                    identity.AddClaim(new Claim(ClaimTypes.Role,roleName,ClaimValueTypes.String));
                }

                var ticket = new AuthenticationTicket(identity,CreateProperties(username));
                ticket.Properties.IssuedUtc = DateTime.UtcNow;
                ticket.Properties.ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

                var token = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
                result.Token = token;
                result.Permissions = permissions.ToList();
                result.Status = 0;
            }
            return result;
        }
    }
}
