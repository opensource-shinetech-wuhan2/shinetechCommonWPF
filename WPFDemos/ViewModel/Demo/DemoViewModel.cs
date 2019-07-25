using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Common;
using WPFDemos.Views.Demo;

namespace WPFDemos.ViewModel.Demo
{
    public interface IDemoViewModel { }
    public class DemoViewModel :ViewModelBase, IDemoViewModel
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

        public RelayCommand PluginImportCommand { get; set; }

        public RelayCommand PermissionCommand { get; set; }

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
            PluginImportCommand = new RelayCommand(ShowPluginImportWindow);
            PermissionCommand = new RelayCommand(ShowPermissionWindow);
        }

        public void ShowSwitchDataContextWindow ()
        {
            WindowManager.ShowWindow(typeof(SwitchDataContext));
        }

        public void ShowDataTemplateWindow ()
        {
            WindowManager.ShowWindow(typeof(DataTemplateView));
        }

        public void ShowControlTemplateWindow ()
        {
            WindowManager.ShowWindow(typeof(ControlTemplateView));
        }

        public void ShowConverterWindow ()
        {
            WindowManager.ShowWindow(typeof(ConverterView));
        }

        public void ShowResourceWindow ()
        {
            WindowManager.ShowWindow(typeof(ResourceView));
        }

        public void ShowBindingWindow ()
        {
            WindowManager.ShowWindow(typeof(BindingView));
        }

        public void ShowCustomControlWindow ()
        {
            WindowManager.ShowWindow(typeof(CustomControlView));
        }

        public void ShowTreeViewWindow ()
        {
            WindowManager.ShowWindow(typeof(TreeViewView));
        }

        public void ShowValidationWindow ()
        {
            WindowManager.ShowWindow(typeof(ValidationView));
        }

        public void ShowPdfViewerWindow ()
        {
            WindowManager.ShowWindow(typeof(PdfViewerView));
        }

        public void ShowPluginImportWindow ()
        {
            WindowManager.ShowWindow(typeof(PluginImportView));
        }

        public void ShowPermissionWindow ()
        {
            WindowManager.ShowWindow(typeof(PermissionView));
        }
    }
}
