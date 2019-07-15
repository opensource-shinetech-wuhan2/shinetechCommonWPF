using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace WPFDemos.Common
{
    public static class MessageManager<T>
    {
        public static void Register(object recipient, Action<T> action)
        {
            Messenger.Default.Register(recipient,action);
        }

        public static void Send (T message)
        {
            Messenger.Default.Send(message);
        }

        public static void UnRegister (object recipient,Action<T> action)
        {
            Messenger.Default.Unregister(recipient,action);
        }
    }
}
