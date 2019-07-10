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
    public class AuthorDataContext:IDataContext
    {
        public string Name { get; set; }

        public object Content { get; set; }

        public DataTemplate DataTemplate { get; set; }

        public AuthorDataContext ()
        {
            Content = new Person{ Name = "Anders", Age = 56, Job = "Developer"};

            DataTemplate = new DataTemplate();

            FrameworkElementFactory f1 = new FrameworkElementFactory(typeof(Author));

            Binding bind = new Binding();
            f1.SetBinding(Author.DataContextProperty,bind);
            DataTemplate.VisualTree = f1;
        }
    }
}
