using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Business.Model
{
    public class MenuModel:ObservableObject
    {
        public int Id { get; set; }
        public int? Pid { get; set; }

        private string _name;

        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Set(ref _name,value);
            }
        }
        public int Type { get; set; }
        public virtual ObservableCollection<MenuModel> Children { get; set; }
        public virtual MenuModel Parent { get; set; }
        public string Icon { get; set; }        
    }
}
