using SliderRgb.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SliderRgb.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private byte _redColor = 0;
        public byte RedColor
        {
            get { return _redColor; }
            set
            {
                _redColor = value;
                OnPropertyChanged(nameof(RedColor), nameof(RectColor));
            }
        }

        private byte _greenColor = 0;
        public byte GreenColor
        {
            get { return _greenColor; }
            set
            {
                _greenColor = value;
                OnPropertyChanged(nameof(GreenColor), nameof(RectColor));
            }
        }

        private byte _blueColor = 0;
        public byte BlueColor
        {
            get { return _blueColor; }
            set
            {
                _blueColor = value;
                OnPropertyChanged(nameof(BlueColor), nameof(RectColor));
            }
        }


        private Color _rectColor;
        public Color RectColor
        {
            get
            {
                return _rectColor = Color.FromRgb(RedColor, GreenColor, BlueColor);
            }
            set
            {
                _rectColor = value;
                OnPropertyChanged(nameof(RectColor));
            }
        }


        #region Commands

        private ICommand _setToRed;

        public ICommand SetToRed
        {
            get
            {
                if (_setToRed == null) _setToRed = new RelayCommand(
                    (object o) =>
                    {
                        RedColor = 255;
                        GreenColor = 0;
                        BlueColor = 0;
                    },
                    (object o) => true);
                return _setToRed;
            }
        }


        #endregion
    }
}
