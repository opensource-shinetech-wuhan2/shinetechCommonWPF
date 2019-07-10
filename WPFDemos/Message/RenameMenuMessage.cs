using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFDemos.Message
{
    public class RenameMenuMessage
    {
        public bool IsSaved { get; set; }
        public TreeViewItem TreeViewItem { get; set; }
    }
}
