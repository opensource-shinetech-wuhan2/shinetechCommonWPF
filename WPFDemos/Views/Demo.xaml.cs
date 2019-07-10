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

namespace WPFDemos.Views
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo :Window
    {
        public Demo ()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this,NotificationMessageReceived);

            Unloaded += Demo_Unloaded;
        }

        private void Demo_Unloaded (object sender,RoutedEventArgs e)
        {
            Messenger.Default.Unregister<NotificationMessage>(this);
        }

        private void NotificationMessageReceived (NotificationMessage msg)
        {
            Window view = null;
            switch(msg.Notification)
            {
                case "ShowSwitchDataContextWindow":
                    view = new SwitchDataContext();
                    view.ShowDialog();
                    break;
                case "ShowDataTemplateWindow":
                    view = new DataTemplateView();
                    view.ShowDialog();
                    break;
                case "ShowControlTemplateWindow":
                    view = new ControlTemplateView();
                    view.ShowDialog();
                    break;
                case "ShowConverterWindow":
                    view = new ConverterView();
                    view.ShowDialog();
                    break;
                case "ShowResourceWindow":
                    view = new ResourceView();
                    view.ShowDialog();
                    break;
                case "ShowBindingWindow":
                    view = new BindingView();
                    view.ShowDialog();
                    break;
                case "ShowCustomControlWindow":
                    view = new CustomControlView();
                    view.ShowDialog();
                    break;
                case "ShowTreeViewWindow":
                    view = new TreeViewView();
                    view.ShowDialog();
                    break;
                case "ShowValidationWindow":
                    view = new ValidationView();
                    view.ShowDialog();
                    break;
                case "ShowPdfViewerWindow":
                    view = new PdfViewerView();
                    view.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
