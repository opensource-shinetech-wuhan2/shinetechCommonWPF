using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFDemos.CustomControl
{
    public class NumericTextBox:TextBox
    {
        private const string UpButtonKey = "PART_UpButton";
        private const string DownButtonKey = "PART_DownButton";
        private Button _btnUp;
        private Button _btnDown;

        public override void OnApplyTemplate ()
        {
            base.OnApplyTemplate();

            _btnUp = Template.FindName(UpButtonKey,this) as Button;
            _btnDown = Template.FindName(DownButtonKey,this) as Button;

            _btnUp.Click += delegate { Operate("+"); };
            _btnDown.Click += delegate { Operate("-"); };
        }

        private void Operate (string operation)
        {
            int input = 0;

            if(int.TryParse(this.Text,out input))
            {
                if(operation == "+")
                {
                    this.Text = (input + 1).ToString();
                }
                else
                {
                    this.Text = (input - 1).ToString();
                }
            }
        }
    }
}
