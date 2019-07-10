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

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DemoViewModel>();
            SimpleIoc.Default.Register<SwitchDataContextViewModel>();
            SimpleIoc.Default.Register<DataTemplateViewModel>();
            SimpleIoc.Default.Register<ControlTemplateViewModel>();
            SimpleIoc.Default.Register<ConverterViewModel>();
            SimpleIoc.Default.Register<ResourceViewModel>();
            SimpleIoc.Default.Register<BindingViewModel>();
            SimpleIoc.Default.Register<CustomControlViewModel>();
            SimpleIoc.Default.Register<TreeViewViewModel>();
            SimpleIoc.Default.Register<ValidationViewModel>();
            SimpleIoc.Default.Register<PdfViewerViewModel>();
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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}