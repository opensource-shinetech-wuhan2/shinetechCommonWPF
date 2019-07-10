using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPFDemos.UserControls;

namespace WPFDemos.Data
{
    public class PeopleDataContext :IDataContext
    {
        public string Name { get; set; }

        public object Content { get; set; }

        public DataTemplate DataTemplate { get; set; }

        public PeopleDataContext ()
        {
            Content = new List<Person> {
                new Person { Name = "Anders",Age = 56,Job = "Developer" },
                new Person { Name = "Lucy",Age = 56,Job = "Teacher" },
                new Person { Name = "Tom",Age = 56,Job = "Student" },
                new Person { Name = "Jacky",Age = 56,Job = "Movie Star" }
            };

            DataTemplate = new DataTemplate();

            FrameworkElementFactory f1 = new FrameworkElementFactory(typeof(PeopleControl));

            Binding bind = new Binding();
            f1.SetBinding(PeopleControl.DataContextProperty,bind);
            DataTemplate.VisualTree = f1;
        }
    }
}
