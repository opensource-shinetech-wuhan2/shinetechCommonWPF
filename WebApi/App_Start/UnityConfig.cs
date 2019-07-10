using System.Web.Http;
using AutoMapper;
using Business;
using Business.IBusiness;
using Unity;
using Unity.WebApi;
using WebApi.Common;
using WebApi.DI;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            UnityDependencyRegister.Register(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}