using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WPFDemos.Views.Demo;

namespace WPFDemos.Views
{
    public class ViewLocator
    {
        public ViewLocator ()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<SwitchDataContext>();
            SimpleIoc.Default.Register<DataTemplateView>();
            SimpleIoc.Default.Register<ControlTemplateView>();
            SimpleIoc.Default.Register<ConverterView>();
            SimpleIoc.Default.Register<ResourceView>();
            SimpleIoc.Default.Register<BindingView>();
            SimpleIoc.Default.Register<CustomControlView>();
            SimpleIoc.Default.Register<TreeViewView>();
            SimpleIoc.Default.Register<ValidationView>();
            SimpleIoc.Default.Register<PdfViewerView>();
            SimpleIoc.Default.Register<PluginImportView>();
        }
    }
}
