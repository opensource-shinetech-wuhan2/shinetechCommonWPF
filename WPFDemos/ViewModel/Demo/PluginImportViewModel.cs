using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Plugin;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UserControlPlugin;

namespace WPFDemos.ViewModel.Demo
{
    public class PluginImportViewModel:ViewModelBase
    {
        public RelayCommand ImportPluginCommand { get; protected set; }

        [ImportMany(typeof(IView))]
        private List<Lazy<IView,IMetaData>> _plugins;

        private IView _pluginView;
        public IView PluginView
        {
            get { return _pluginView; }
            set
            {
                Set(ref _pluginView,value);
            }
        }

        public PluginImportViewModel ()
        {
            ImportPluginCommand = new RelayCommand(ImportPluginExecute);
        }

        public void ImportPluginExecute ()
        {           
            PluginManager.LoadPluginsLazy(this);

            var calculatorPlugin = _plugins.Find(p => p.Metadata.Name == "CalculatorScreen");
            if(calculatorPlugin != null)
            {
                PluginView = calculatorPlugin.Value;
            }
        }
    }
}
