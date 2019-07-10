using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business;
using Business.IBusiness;
using Unity;
using WebApi.Common;

namespace WebApi.DI
{
    public static class UnityDependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            //auto mapper
            var mapperConfiguration = new MapperFactory().CreateConfiguration();
            container.RegisterInstance(mapperConfiguration);
            container.RegisterInstance<IMapper>(new Mapper(mapperConfiguration));

            //business
            container.RegisterType<IMenuBusiness,MenuBusiness>();
            container.RegisterType<IPeopleBusiness,PeopleBusiness>();
            container.RegisterType<IClientBusiness,ClientBusiness>();
            container.RegisterType<IStudentBusiness,StudentBusiness>();
            container.RegisterType<ICourseBusiness,CourseBusiness>();
        }
    }
}