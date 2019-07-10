using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFDemos.Converters
{
    public class MultiColorConverter :IMultiValueConverter
    {
        public object Convert (object[] values,Type targetType,object parameter,CultureInfo culture)
        {
            var firstColor = (Color)values[0];
            var secondColor = (Color)values[1];
            RadialGradientBrush brush = new RadialGradientBrush();
            GradientStop gs1 = new GradientStop() {  Offset= 0, Color = firstColor };
            GradientStop gs2 = new GradientStop() { Offset = 1,Color = secondColor };
            brush.GradientStops.Add(gs1);
            brush.GradientStops.Add(gs2);
            return brush;
        }

        public object[] ConvertBack (object value,Type[] targetTypes,object parameter,CultureInfo culture)
        {
            var brush = (RadialGradientBrush)value;
            var color1 = brush.GradientStops[0].Color;
            var color2 = brush.GradientStops[1].Color;
            return new object [] { color1,color2 };
        }
    }
}
