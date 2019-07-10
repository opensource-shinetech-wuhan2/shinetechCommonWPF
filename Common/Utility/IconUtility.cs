using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public class IconUtility
    {
        public static string GetIcon (int type)
        {
            string result = "";
            if(type == 1) result = "../images/folder.png";
            else if(type == 2) result = "../images/menu.png";
            else if(type == 3) result = "../images/image-sm.png";
            return result;
        }
    }
}
