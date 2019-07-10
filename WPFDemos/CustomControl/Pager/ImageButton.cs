using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFDemos.CustomControl.Pager
{
    public class ImageButton:Button
    {
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set {
                SetValue(SourceProperty,value);
            }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",typeof(string),typeof(ImageButton),new PropertyMetadata(null));
    }
}
