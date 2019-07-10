using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentModel> Students { get; set; }
    }
}
