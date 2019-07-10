using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Message;

namespace WPFDemos.Views
{
    /// <summary>
    /// Interaction logic for Resource.xaml
    /// </summary>
    public partial class ResourceView : Window
    {
        public ResourceView ()
        {
            InitializeComponent();
            Messenger.Default.Register<ResourceViewMessage>(this,NotificationMessageReceived);
        }

        private void NotificationMessageReceived (ResourceViewMessage msg)
        {
            Style style = new Style();
            Setter set = new Setter();
            set.Property = Button.BorderBrushProperty;
            set.Value = new SolidColorBrush(Colors.Red);

            Setter set1 = new Setter();
            set1.Property = Button.ForegroundProperty;
            set1.Value = new SolidColorBrush(Colors.Purple);

            style.Setters.Add(set);
            style.Setters.Add(set1);
            this.Resources["btnBorder"] = style;
        }
    }
}
