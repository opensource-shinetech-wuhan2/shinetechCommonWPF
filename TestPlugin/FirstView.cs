using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Plugin;

namespace TestPlugin
{
    [Export(typeof(IView))]
    [CustomExportMetaData("FirstPlugin","","hinson","1.0")]
    public class FirstView:UserControl,IView
    {

    }
}
