using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFDemos.Data
{
    public class ImageDataContext :IDataContext
    {
        public string Name { get; set; }

        public object Content { get; set; }

        public DataTemplate DataTemplate { get; set; }

        public ImageDataContext ()
        {
            Content = "../Images/Homes.png";

            DataTemplate = new DataTemplate();

            FrameworkElementFactory f1 = new FrameworkElementFactory(typeof(Image));
            Binding bind = new Binding();
            f1.SetValue(Image.WidthProperty,100d);
            f1.SetValue(Image.HeightProperty,100d);
            f1.SetValue(Image.SourceProperty,bind);
            DataTemplate.VisualTree = f1;
        }
    }
}
