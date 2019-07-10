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
using Microsoft.Win32;
using WPFDemos.Message;

namespace WPFDemos.Views
{
    /// <summary>
    /// Interaction logic for PdfViewerView.xaml
    /// </summary>
    public partial class PdfViewerView :Window
    {
        private bool _isLoaded;
        public PdfViewerView ()
        {
            InitializeComponent();
            Messenger.Default.Register<PdfViewerMessage>(this,NotificationMessageReceived);
            Unloaded += Demo_Unloaded;
        }

        private void NotificationMessageReceived (PdfViewerMessage message)
        {
            switch(message.CommandType)
            {
                case PdfCommandType.OpenFile:
                    var dialog = new OpenFileDialog();
                    if(dialog.ShowDialog().GetValueOrDefault())
                    {
                        string filePath = dialog.FileName;

                        try
                        {
                            moonPdfPanel.OpenFile(filePath);
                            _isLoaded = true;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            _isLoaded = false;
                        }
                    }
                    break;
                case PdfCommandType.ZoomIn:
                    if(_isLoaded)
                    {
                        moonPdfPanel.ZoomIn();
                    }
                    break;
                case PdfCommandType.ZoomOut:
                    if(_isLoaded)
                    {
                        moonPdfPanel.ZoomOut();
                    }
                    break;
                case PdfCommandType.Normal:
                    if(_isLoaded)
                    {
                        moonPdfPanel.Zoom(1.0);
                    }
                    break;
                case PdfCommandType.Fit:
                    moonPdfPanel.ZoomToHeight();
                    break;
                case PdfCommandType.SinglePage:
                    moonPdfPanel.ViewType = MoonPdfLib.ViewType.SinglePage;
                    break;
                case PdfCommandType.Facing:
                    moonPdfPanel.ViewType = MoonPdfLib.ViewType.Facing;
                    break;
                default:
                    break;
            }
        }

        private void Demo_Unloaded (object sender,RoutedEventArgs e)
        {
            Messenger.Default.Unregister<NotificationMessage>(this);
        }
    }
}
