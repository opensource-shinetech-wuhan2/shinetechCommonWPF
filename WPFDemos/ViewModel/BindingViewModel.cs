using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WPFDemos.ViewModel
{
    public class BindingViewModel:ViewModelBase
    {
        private int _btnFontSize;
        public int BtnFontSize
        {
            get { return _btnFontSize; }
            set
            {
                _btnFontSize = value;
                RaisePropertyChanged("BtnFontSize");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public BindingViewModel ()
        {
            FirstName = "Micheal";
            LastName = "Jackson";
        }
    }
}
