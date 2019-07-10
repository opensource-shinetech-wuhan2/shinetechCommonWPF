using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Model;
using Business.IBusiness;
using Common.Log;
using DataModel;
using Data.Access;

namespace Business
{
    public class StudentBusiness:IStudentBusiness
    {
        private IMapper _mapper;
        private StudentAgent _studentAgent;
        private CourseAgent _courseAgent;
        public StudentBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _studentAgent = new StudentAgent();
            _courseAgent = new CourseAgent();
        }

        public StudentModel GetById (int id)
        {
            var student = _studentAgent.GetById(id);
            var studentDto = _mapper.Map<StudentModel>(student);
            return studentDto;
        }

        public List<StudentModel> GetAll ()
        {
            var students = _studentAgent.GetAll();
            var studentList = _mapper.Map<List<StudentModel>>(students);
            return studentList;
        }

        public StudentModel Add (StudentModel dto)
        {
            try
            {
                var entity = _mapper.Map<StudentModel,Student>(dto,opt=> opt.ConfigureMap().ForMember(dst => dst.Courses,m => m.Ignore()));
                var student = _studentAgent.Add(entity);

                foreach(var course in dto.Courses)
                {
                    entity.Courses.Add(_mapper.Map<Course>(course));
                }
                student = _studentAgent.Update(entity);

                var studentDto = _mapper.Map<StudentModel>(student);
                return studentDto;
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
            return null;
        }

        public StudentModel Update (StudentModel dto)
        {
            try
            {
                var entity = _mapper.Map<Student>(dto);
                var student = _studentAgent.Update(entity);
                var studentDto = _mapper.Map<StudentModel>(student);
                return studentDto;
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
