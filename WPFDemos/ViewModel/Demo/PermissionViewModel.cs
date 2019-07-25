using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFDemos.Common;

namespace WPFDemos.ViewModel.Demo
{
    public class PermissionViewModel :ViewModelBase
    {
        public bool CanView => PermissionManager.HasPermission("ViewUser");
        public RelayCommand ViewCommand { get; set; }

        public PermissionViewModel ()
        {
            ViewCommand = new RelayCommand(View,() => CanView);
        }

        public void View ()
        {
            MessageBox.Show("User View");
        }
    }
}
