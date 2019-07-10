using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFDemos.Data
{
    public class CircleDataContext:IDataContext
    {
        public string Name { get; set; }

        public object Content { get; set; }

        public DataTemplate DataTemplate { get; set; }

        public CircleDataContext ()
        {
            Content = new RadialGradientBrush ();
            ((RadialGradientBrush)Content).GradientStops.Add(new GradientStop { Offset = 0,Color = Color.FromArgb(1,2,3,4) });
            ((RadialGradientBrush)Content).GradientStops.Add(new GradientStop { Offset = 1,Color = Color.FromArgb(77,78,79,90) });

            DataTemplate = new DataTemplate();
            FrameworkElementFactory fef = new FrameworkElementFactory(typeof(Ellipse));
            fef.SetValue(Ellipse.WidthProperty,100d);
            fef.SetValue(Ellipse.HeightProperty,100d);
            Binding binding = new Binding();
            fef.SetValue(Ellipse.FillProperty,binding);
            DataTemplate.VisualTree = fef;
        }
    }
}
