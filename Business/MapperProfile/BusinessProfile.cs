using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Model;
using Common;
using Common.Utility;
using DataModel;

namespace Business.MapperProfile
{
    public class BusinessProfile :Profile
    {
        public BusinessProfile ()
        {
            CreateMap<Menu,MenuModel>()
                .ForMember(dst => dst.Icon,opt => opt.MapFrom((src,dst) =>
                {
                    return IconUtility.GetIcon(src.type);
                }));

            CreateMap<MenuModel,Menu>();

            CreateMap<PersonModel,Person>();
            CreateMap<Person,PersonModel>();

            CreateMap<ClientModel,Client>();
            CreateMap<Client,ClientModel>();

            CreateMap<StudentModel,Student>();//.ForMember(dst => dst.Courses,opt => opt.Ignore());
            CreateMap<Student,StudentModel>();

            CreateMap<CourseModel,Course>();
            CreateMap<Course,CourseModel>();
        }
    }
}
