using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFDemos.Data;

namespace WPFDemos.ViewModel
{
    public class SwitchDataContextViewModel:ViewModelBase
    {
        public RelayCommand<SelectionChangedEventArgs> ContextChangedCommand { get; set; }

        public SwitchDataContextViewModel ()
        {
            ContextChangedCommand = new RelayCommand<SelectionChangedEventArgs>(ContextChanged);
        }

        private IDataContext _buttonDataContext;
        public IDataContext ButtonDataContext
        {
            get { return _buttonDataContext; }
            set
            {
                _buttonDataContext = value;
                RaisePropertyChanged("ButtonDataContext");
            }
        }

        private IDataContext _mainDataContext;
        public IDataContext MainDataContext
        {
            get { return _mainDataContext; }
            set
            {
                _mainDataContext = value;
                RaisePropertyChanged("MainDataContext");
            }
        }

        public void ContextChanged (SelectionChangedEventArgs eventArg)
        {
            var cmb = (ComboBox)eventArg.Source;
            var cmbItem = (ComboBoxItem)cmb.SelectedItem;
            var contextName = cmbItem.Content.ToString();
            if(contextName == "context1")
            {
                ButtonDataContext = new CircleDataContext();
                MainDataContext = new AuthorDataContext();
            }
            else if(contextName == "context2")
            {
                ButtonDataContext = new ImageDataContext();
                MainDataContext = new PeopleDataContext();
            }
        }
    }
}
