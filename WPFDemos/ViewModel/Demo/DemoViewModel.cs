using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Common;

namespace WPFDemos.ViewModel.Demo
{
    public class DemoViewModel :ViewModelBase
    {
        public RelayCommand SwitchDataContextCommand { get; set; }
        public RelayCommand DataTemplateCommand { get; set; }
        public RelayCommand ControlTemplateCommand { get; set; }
        public RelayCommand ConverterCommand { get; set; }
        public RelayCommand ResourceCommand { get; set; }
        public RelayCommand BindingCommand { get; set; }
        public RelayCommand CustomControlCommand { get; set; }
        public RelayCommand TreeViewCommand { get; set; }
        public RelayCommand ValidationCommand { get; set; }
        public RelayCommand PdfViewerCommand { get; set; }
        public DemoViewModel ()
        {
            SwitchDataContextCommand = new RelayCommand(ShowSwitchDataContextWindow);
            DataTemplateCommand = new RelayCommand(ShowDataTemplateWindow);
            ControlTemplateCommand = new RelayCommand(ShowControlTemplateWindow);
            ConverterCommand = new RelayCommand(ShowConverterWindow);
            ResourceCommand = new RelayCommand(ShowResourceWindow);
            BindingCommand = new RelayCommand(ShowBindingWindow);
            CustomControlCommand = new RelayCommand(ShowCustomControlWindow);
            TreeViewCommand = new RelayCommand(ShowTreeViewWindow);
            ValidationCommand = new RelayCommand(ShowValidationWindow);
            PdfViewerCommand = new RelayCommand(ShowPdfViewerWindow);
        }

        public void ShowSwitchDataContextWindow ()
        {
            WindowManager.ShowWindow("ShowSwitchDataContextWindow");
        }

        public void ShowDataTemplateWindow ()
        {
            WindowManager.ShowWindow("ShowDataTemplateWindow");
        }

        public void ShowControlTemplateWindow ()
        {
            WindowManager.ShowWindow("ShowControlTemplateWindow");
        }

        public void ShowConverterWindow ()
        {
            WindowManager.ShowWindow("ShowConverterWindow");
        }

        public void ShowResourceWindow ()
        {
            WindowManager.ShowWindow("ShowResourceWindow");
        }

        public void ShowBindingWindow ()
        {
            WindowManager.ShowWindow("ShowBindingWindow");
        }

        public void ShowCustomControlWindow ()
        {
            WindowManager.ShowWindow("ShowCustomControlWindow");
        }

        public void ShowTreeViewWindow ()
        {
            WindowManager.ShowWindow("ShowTreeViewWindow");
        }

        public void ShowValidationWindow ()
        {
            WindowManager.ShowWindow("ShowValidationWindow");
        }

        public void ShowPdfViewerWindow ()
        {
            WindowManager.ShowWindow("ShowPdfViewerWindow");
        }
    }
}
