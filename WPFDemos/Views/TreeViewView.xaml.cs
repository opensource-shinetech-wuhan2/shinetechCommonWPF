using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Message;

namespace WPFDemos.Views
{
    /// <summary>
    /// Interaction logic for TreeViewView.xaml
    /// </summary>
    public partial class TreeViewView :Window
    {
        public TreeViewView ()
        {
            InitializeComponent();
            Messenger.Default.Register<RenameMenuMessage>(this,NotificationMessageReceived);
        }

        private void NotificationMessageReceived (RenameMenuMessage msg)
        {
            var item = msg.TreeViewItem;
            var tbShow = GetChildObject<TextBlock>(item,"tbShow");
            var tbEdit = GetChildObject<TextBox>(item,"tbEdit");


            tbShow.Visibility = msg.IsSaved ? Visibility.Visible : Visibility.Collapsed;
            tbEdit.Visibility = msg.IsSaved ? Visibility.Collapsed : Visibility.Visible;
            if(!msg.IsSaved)
            {
                tbEdit.SelectAll();
                tbEdit.Focus(); 
            }
        }

        public T GetChildObject<T> (DependencyObject obj,string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            T grandChild = null;


            for(int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj,i);


                if(child is T && (((T)child).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)child;
                }
                else
                {
                    grandChild = GetChildObject<T>(child,name);
                    if(grandChild != null)
                        return grandChild;
                }
            }
            return null;
        }
    }
}
