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
    class CompareCourse :IEqualityComparer<Course>
    {
        public bool Equals (Course x,Course y)
        {
            return x.id == y.id;
        }

        public int GetHashCode (Course p)
        {
            if(p == null)
                return 0;
            return p.id.GetHashCode();
        }
    }

    public class StudentAgent
    {
        public Student GetById (int id)
        {
            using(var context = new TestEntities())
            {
                var stu = context.Students.Include(p => p.Courses).FirstOrDefault(p => p.id == id);
                return stu;
            }
        }

        public List<Student> GetAll ()
        {
            using(var context = new TestEntities())
            {
                var students = context.Students.ToList();
                return students;
            }
        }

        //add many2many:make sure the navigation attribute empty
        public Student Add (Student student)
        {
            using(var context = new TestEntities())
            {
                context.Students.AddOrUpdate(student);
                int count = context.SaveChanges();
                return student;
            }
        }

        //update many2many
        public Student Update (Student student)
        {
            using(var context = new TestEntities())
            {
                var studentInDb = context.Students.Include(s=>s.Courses).FirstOrDefault(s => s.id == student.id);

                var deletedCourses = studentInDb.Courses.Except(student.Courses,new CompareCourse()).ToList();
                var addedCourses = student.Courses.Except(studentInDb.Courses,new CompareCourse()).ToList();
                deletedCourses.ForEach(c => studentInDb.Courses.Remove(c));

                foreach(var c in addedCourses)
                {
                    if(context.Entry(c).State ==  EntityState.Detached)
                        context.Courses.Attach(c);

                    studentInDb.Courses.Add(c);
                }

                int count = context.SaveChanges();
                return student;
            }
        }
    }
}
