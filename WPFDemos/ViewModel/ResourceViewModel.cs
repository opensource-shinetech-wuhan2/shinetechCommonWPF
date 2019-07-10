using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Message;

namespace WPFDemos.ViewModel
{
    public class ResourceViewModel:ViewModelBase
    {
        
        public RelayCommand UpdateResourceCommand { get; set; }

        public ResourceViewModel ()
        {
            UpdateResourceCommand = new RelayCommand(UpdateResource);
        }

        public void UpdateResource ()
        {
            Messenger.Default.Send(new ResourceViewMessage { Color = Colors.Red });
        }
    }
}
