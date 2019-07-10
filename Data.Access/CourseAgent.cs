using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataModel;

namespace Data.Access
{
    public class CourseAgent
    {
        public Course GetById (int id)
        {
            using(var context = new TestEntities())
            {
                var course = context.Courses.Include(p => p.Students).FirstOrDefault(p => p.id == id);
                return course;
            }
        }

        public List<Course> GetAll ()
        {
            using(var context = new TestEntities())
            {
                var courses = context.Courses.ToList();
                return courses;
            }
        }

        public Course AddOrUpdate (Course course)
        {
            using(var context = new TestEntities())
            {
                context.Courses.AddOrUpdate(course);
                int count = context.SaveChanges();
                return course;
            }
        }
    }
}
