using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Model;
using Business.IBusiness;
using DataModel;
using Data.Access;

namespace Business
{
    public class CourseBusiness:ICourseBusiness
    {
        private IMapper _mapper;
        private CourseAgent _courseAgent;
        public CourseBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _courseAgent = new CourseAgent();
        }

        public CourseModel GetById (int id)
        {
            var course = _courseAgent.GetById(id);
            var courseDto = _mapper.Map<CourseModel>(course);
            return courseDto;
        }

        public List<CourseModel> GetAll ()
        {
            var courses = _courseAgent.GetAll();
            var courseList = _mapper.Map<List<CourseModel>>(courses);
            return courseList;
        }

        public CourseModel Add (CourseModel dto)
        {
            try
            {
                var entity = _mapper.Map<Course>(dto);
                var course = _courseAgent.AddOrUpdate(entity);
                var courseDto = _mapper.Map<CourseModel>(course);
                return courseDto;
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
