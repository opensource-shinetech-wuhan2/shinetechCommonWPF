using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFDemos.Converters
{
    public class TimeConverter :IValueConverter
    {
        public object Convert (object value,Type targetType,object parameter,CultureInfo culture)
        {
            if(value == null) return DependencyProperty.UnsetValue;
            DateTime date = (DateTime)value;
            return date.ToString("yyyy-MM-dd");
        }

        public object ConvertBack (object value,Type targetType,object parameter,CultureInfo culture)
        {
            string dateStr = value as string;
            DateTime date;
            if(DateTime.TryParse(dateStr,out date))
            {
                return date;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
