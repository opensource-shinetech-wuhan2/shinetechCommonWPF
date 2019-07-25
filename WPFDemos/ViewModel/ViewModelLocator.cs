/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPFDemos"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Windows;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using WPFDemos.ViewModel.Demo;
using WPFDemos.Views.Demo;

namespace WPFDemos.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {        
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<DemoViewModel>();
            //SimpleIoc.Default.Register<SwitchDataContextViewModel>();
            //SimpleIoc.Default.Register<DataTemplateViewModel>();
            //SimpleIoc.Default.Register<ControlTemplateViewModel>();
            //SimpleIoc.Default.Register<ConverterViewModel>();
            //SimpleIoc.Default.Register<ResourceViewModel>();
            //SimpleIoc.Default.Register<BindingViewModel>();
            //SimpleIoc.Default.Register<CustomControlViewModel>();
            //SimpleIoc.Default.Register<TreeViewViewModel>();
            //SimpleIoc.Default.Register<ValidationViewModel>();
            //SimpleIoc.Default.Register<PdfViewerViewModel>();
            //SimpleIoc.Default.Register<PluginImportViewModel>();
            //SimpleIoc.Default.Register<PermissionViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public DemoViewModel Demo
        {
            get
            {
                var ins = ServiceLocator.Current.GetInstance(typeof(DemoViewModel));
                return ServiceLocator.Current.GetInstance<DemoViewModel>();
            }
        }

        public SwitchDataContextViewModel SwitchDataContext
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SwitchDataContextViewModel>();
            }
        }

        public DataTemplateViewModel DataTemplateView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DataTemplateViewModel>();
            }
        }

        public ControlTemplateViewModel ControlTemplateView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ControlTemplateViewModel>();
            }
        }

        public ConverterViewModel ConverterView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConverterViewModel>();
            }
        }

        public ResourceViewModel ResourceView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResourceViewModel>();
            }
        }

        public BindingViewModel BindingView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindingViewModel>();
            }
        }

        public CustomControlViewModel CustomControlView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomControlViewModel>();
            }
        }

        public TreeViewViewModel TreeViewView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TreeViewViewModel>();
            }
        }

        public ValidationViewModel ValidationView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidationViewModel>();
            }
        }

        public PdfViewerViewModel PdfViewerView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PdfViewerViewModel>();
            }
        }

        public PluginImportViewModel PluginImportView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PluginImportViewModel>();
            }
        }

        public PermissionViewModel PermissionView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PermissionViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}