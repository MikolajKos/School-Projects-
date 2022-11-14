using ConvertersWpf.Core;
using ConvertersWpf.MVVM.Models;
using ConvertersWpf.MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConvertersWpf.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        MainModel model = new MainModel(); 

        private Visibility _isVisible = Visibility.Visible;
        public Visibility IsVisible 
        {
            get
            {
                return _isVisible; 
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }


        private string _myTest;
        public string MyTest
        {
            get { return _myTest; }
            set 
            { 
                _myTest = value;
                OnPropertyChanged(nameof(_myTest));
            }
        }

        private ICommand _changeVisibility = null;
        public ICommand ChangeVisibility
        {
            get
            {
                if (_changeVisibility == null) _changeVisibility = new RelayCommand(
                    (object o) =>
                    {
                        // ChangeCurrentVisibility changeVis = new ChangeCurrentVisibility(IsVisible);
                        IsVisible = Visibility.Hidden;//changeVis.ChangeMyVisibility();
                    },
                    (object o) =>
                    {
                        return true;
                    });
                return _changeVisibility;
            }
        }



    }
}
