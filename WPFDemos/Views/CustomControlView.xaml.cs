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

namespace WPFDemos.Views
{
    /// <summary>
    /// Interaction logic for CustomControlView.xaml
    /// </summary>
    public partial class CustomControlView : Window
    {
        public CustomControlView()
        {
            InitializeComponent();
        }

        private void Window_Activated (object sender,EventArgs e)
        {
            
        }

        private void Pager1_PageChanged (object sender,CustomControl.Pager.DataPager.PageChangedEventArgs e)
        {

        }
    }
}
