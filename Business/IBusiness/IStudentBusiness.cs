using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IStudentBusiness
    {
        StudentModel GetById (int id);

        List<StudentModel> GetAll ();

        StudentModel Add (StudentModel dto);

        StudentModel Update (StudentModel dto);
    }
}
