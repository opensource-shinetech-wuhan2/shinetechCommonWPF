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
    public class ColorToBrushConverter :IValueConverter
    {
        public object Convert (object value,Type targetType,object parameter,CultureInfo culture)
        {
            var color = (Color)value;
            return new SolidColorBrush { Color = color };
        }

        public object ConvertBack (object value,Type targetType,object parameter,CultureInfo culture)
        {
            var brush = (SolidColorBrush)value;
            return brush.Color;
        }
    }
}
