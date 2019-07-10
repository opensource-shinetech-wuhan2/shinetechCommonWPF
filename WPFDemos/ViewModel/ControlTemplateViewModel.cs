using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WPFDemos.Data;

namespace WPFDemos.ViewModel
{
    public class ControlTemplateViewModel:ViewModelBase
    {
        public ObservableCollection<Person> _datas;
        public ObservableCollection<Person> Datas
        {
            get { return _datas; }
            set
            {
                _datas = value;
                RaisePropertyChanged("Datas");
            }
        }

        public ControlTemplateViewModel ()
        {
            Datas = new ObservableCollection<Person> {
                    new Person { Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." },
                    new Person { Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" },
                    new Person { Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " },
                    new Person { Name = "Jacky",Age = 56,Job = "Movie Star", Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" }
                };
        }
    }
}
