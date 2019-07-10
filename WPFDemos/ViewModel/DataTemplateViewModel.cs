using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WPFDemos.ViewModel
{
    public class Template
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string HeaderImage { get; set; }
    }
    public class DataTemplateViewModel:ViewModelBase
    {
        public ObservableCollection<Template> _datas;
        public ObservableCollection<Template> Datas {
            get { return _datas; }
            set {
                _datas = value;
                RaisePropertyChanged("Datas");
            }
        }

        public DataTemplateViewModel ()
        {
            Datas = new ObservableCollection<Template> {
                new Template{ Name = "name 1", IsEnabled = true, HeaderImage = "../Images/add.png" },
                new Template{ Name = "name 2", IsEnabled = false, HeaderImage = "../Images/delete.png" },
                new Template{ Name = "name 3", IsEnabled = true, HeaderImage = "../Images/edit.png" },
                new Template{ Name = "name 4", IsEnabled = false, HeaderImage = "../Images/Search.png" }
            };
        }
    }
}
