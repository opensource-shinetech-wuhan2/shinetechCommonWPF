using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFDemos.CustomControl
{
    public class ExDataGrid:DataGrid
    {
        protected override void OnItemsSourceChanged (IEnumerable oldValue,IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue,newValue);
            if(Items.Count > 0) ScrollIntoView(Items[0]);
        }        
    }
}
