using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Plugin;

namespace UserControlPlugin
{
    /// <summary>
    /// Interaction logic for CalculatorScreen.xaml
    /// </summary>
    [Export(typeof(IView))]
    [CustomExportMetaData("CalculatorScreen","","hinson","1.0")]
    public partial class CalculatorScreen :UserControl,IView
    {
        public CalculatorScreen ()
        {
            InitializeComponent();
        }
    }
}
