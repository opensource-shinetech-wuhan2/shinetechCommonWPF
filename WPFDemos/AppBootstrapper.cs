using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using WPFDemos.ViewModel.Demo;
using WPFDemos.Views.Demo;

namespace WPFDemos
{
    public class AppBootstrapper
    {
        public AppBootstrapper ()
        {
            Initialize();
        }

        public void Initialize ()
        {
            var builder = new ContainerBuilder();

            //view model
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<DemoViewModel>();
            builder.RegisterType<SwitchDataContextViewModel>();
            builder.RegisterType<DataTemplateViewModel>();
            builder.RegisterType<ControlTemplateViewModel>();
            builder.RegisterType<ConverterViewModel>();
            builder.RegisterType<ResourceViewModel>();
            builder.RegisterType<BindingViewModel>();
            builder.RegisterType<CustomControlViewModel>();
            builder.RegisterType<TreeViewViewModel>();
            builder.RegisterType<ValidationViewModel>();
            builder.RegisterType<PdfViewerViewModel>();
            builder.RegisterType<PluginImportViewModel>();
            builder.RegisterType<PermissionViewModel>();

            //view
            builder.RegisterType<SwitchDataContext>();
            builder.RegisterType<DataTemplateView>();
            builder.RegisterType<ControlTemplateView>();
            builder.RegisterType<ConverterView>();
            builder.RegisterType<ResourceView>();
            builder.RegisterType<BindingView>();
            builder.RegisterType<CustomControlView>();
            builder.RegisterType<TreeViewView>();
            builder.RegisterType<ValidationView>();
            builder.RegisterType<PdfViewerView>();
            builder.RegisterType<PluginImportView>();
            builder.RegisterType<PermissionView>();


            var container = builder.Build();
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}
