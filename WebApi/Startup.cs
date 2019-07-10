using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(WebApi.Startup))]
namespace WebApi
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        static Startup ()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public void Configuration (IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}