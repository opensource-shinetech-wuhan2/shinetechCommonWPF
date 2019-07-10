using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi.Common;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {          
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(JsonConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Register);
            //ioc
            UnityConfig.RegisterComponents();
        }
    }
}
