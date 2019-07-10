using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Business.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFDemos.Common.ValidationRules;

namespace WPFDemos.ViewModel
{
    public class ValidationViewModel:ViewModelBase
    {
        //private PersonModel _person;
        public PersonModel Person { get; set; }

        public RelayCommand SaveCommand { get; set; }

        public ValidationViewModel ()
        {
            Person = new PersonModel();
            SaveCommand = new RelayCommand(Save);
        }

        public void Save ()
        {
            if(Person.IsValid())
            {

            }
        }
    }
}
