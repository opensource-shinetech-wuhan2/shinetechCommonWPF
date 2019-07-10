using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface ICourseBusiness
    {
        CourseModel GetById (int id);

        List<CourseModel> GetAll ();

        CourseModel Add (CourseModel dto);
    }
}
