using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace WPFDemos.ViewModel
{
    public class ConverterViewModel:ViewModelBase
    {
        private DateTime _createDate;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set {
                _createDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }


        private Color _firstColor;
        public Color FirstColor {
            get { return _firstColor; }
            set { _firstColor = value;

                var b = _firstColor == Colors.Blue;
                RaisePropertyChanged("FirstColor");
            }
        }

        private Color _secondColor;
        public Color SecondColor
        {
            get { return _secondColor; }
            set
            {
                _secondColor = value;
                RaisePropertyChanged("SecondColor");
            }
        }

        private List<Color> _colorItems;
        public List<Color> ColorItems
        {
            get { return _colorItems; }
            set
            {
                _colorItems = value;
                RaisePropertyChanged("ColorItems");
            }
        }

        public ConverterViewModel ()
        {
            CreateDate = DateTime.Now;
            ColorItems = new List<Color>();
            ColorItems.Add(Colors.Blue);
            ColorItems.Add(Colors.Black);
            ColorItems.Add(Colors.Red);
            ColorItems.Add(Colors.Green);
            ColorItems.Add(Colors.Yellow);
        }
    }
}
