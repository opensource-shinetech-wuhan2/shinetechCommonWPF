using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFDemos.Data;
using static WPFDemos.CustomControl.Pager.DataPager;

namespace WPFDemos.ViewModel
{
    public class CustomControlViewModel :ViewModelBase
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set {
                _value = value;
                RaisePropertyChanged("Value");
            }

        }

        static List<Person> Persons = new List<Person>();

        static CustomControlViewModel ()
        {
            Persons.Add(new Person { Id = 1, Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 2,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 3,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 4,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 5,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 6,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 7,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 8,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 9,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 10,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 11,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 12,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 13,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 14,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 15,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 16,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 17,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 18,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 19,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 20,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 21,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 22,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 23,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 24,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 25,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 26,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 27,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 28,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 29,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 30,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 31,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 32,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 33,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 34,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 35,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 36,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 37,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 38,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 39,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 40,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 41,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 42,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 43,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 44,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 45,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 46,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 47,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 48,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 49,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 50,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 51,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 52,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 53,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 54,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 55,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 56,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 57,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 58,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 59,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 60,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 61,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 62,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 63,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 64,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 65,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            Persons.Add(new Person { Id = 66,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            Persons.Add(new Person { Id = 67,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            Persons.Add(new Person { Id = 68,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            Persons.Add(new Person { Id = 69,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 70,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 71,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 72,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 73,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 74,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 75,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 76,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 77,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 78,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 79,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 80,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 81,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 82,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 83,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 84,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 85,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 86,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 87,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 88,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 89,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 90,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 91,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 92,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
            //Persons.Add(new Person { Id = 93,Name = "Anders",Age = 56,Job = "Developer",Desc = "My Name is the debut album by French singer-songwriter Mélanie Pain. After singing for new wave band Nouvelle Vague, Pain completed recording her first album, releasing it on April 21, 2009." });
            //Persons.Add(new Person { Id = 94,Name = "Lucy",Age = 56,Job = "Teacher",Desc = "Till the day I let you go, Until we say our next hello its not goodbye" });
            //Persons.Add(new Person { Id = 95,Name = "Tom",Age = 56,Job = "Student",Desc = "Hello , everyone ! Now , I want to talk with someone about me , but no one in here , so I write the words down instead of it . " });
            //Persons.Add(new Person { Id = 96,Name = "Jacky",Age = 56,Job = "Movie Star",Desc = "Hello! what can i do for you? Would you need some help? May i know your name please?" });
        }

        public RelayCommand<PageChangedEventArgs> PageChangeCommand { get; set; }

        public List<Person> _datas;
        public List<Person> Datas
        {
            get { return _datas; }
            set
            {
                _datas = value;
                RaisePropertyChanged("Datas");
            }
        }

        private int _total;
        public int Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }

        public CustomControlViewModel ()
        {
            PageChangeCommand = new RelayCommand<PageChangedEventArgs>(PageChanged);
            Total = Persons.Count;
        }

        public void FetchData (int pageIndex,int pageSize)
        {        
            Datas = Persons.Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();          
        }

        public void PageChanged (PageChangedEventArgs e)
        {
            FetchData(e.PageIndex,e.PageSize);
        }
    }
}
