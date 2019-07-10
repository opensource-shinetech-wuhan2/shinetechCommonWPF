using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace WPFDemos.Common
{
    public static class WindowManager
    {
        public static void ShowWindow (string windowName)
        {
            Messenger.Default.Send(new NotificationMessage(windowName));
        }
    }
}
