using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemos.Message
{
    public class ShowWindowMessage
    {
        public Type WindowType { get; set; }

        public ShowWindowMessage (Type _windowType) {
            WindowType = _windowType;
        }
    }
}
