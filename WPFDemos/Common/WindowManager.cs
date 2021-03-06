﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Message;
using WPFDemos.Views.Demo;

namespace WPFDemos.Common
{
    public class WindowLisener
    {
        public WindowLisener ()
        {
            MessageManager<ShowWindowMessage>.Register(this,ShowWindowHandler);
        }

        public static void ShowWindowHandler (ShowWindowMessage msg)
        {
            Window view = ServiceLocator.Current.GetInstance(msg.WindowType) as Window;
            view.ShowDialog();            
        }
    }

    public static class WindowManager
    {
        private static WindowLisener lisener = new WindowLisener();

        public static void ShowWindow (Type windowType)
        {
            MessageManager<ShowWindowMessage>.Send(new ShowWindowMessage(windowType));
        }

        public static void ShowErrorWindow (int statusCode)
        {
            string message = "";
            switch(statusCode)
            {
                case 401:
                    message = "have no right to  operate";
                    break;
                default:
                    break;
            }

            MessageBox.Show(message);
        }
    }
}
