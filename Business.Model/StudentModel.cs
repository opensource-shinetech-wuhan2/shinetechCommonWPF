using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CourseModel> Courses { get; set; }
    }
}
