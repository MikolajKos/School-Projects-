using OnlyBinding.Converters;
using OnlyBinding.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlyBinding.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        
        private string _welcomeMesage;
        public string WelcomeMessage
        {
            get 
            { 
                return _welcomeMesage; 
            }
            set
            { 
                _welcomeMesage = value;
                OnPropertyChanged(nameof(WelcomeMessage));
            }
        }



        private ICommand _getUserName = null;
        public ICommand GetUserName
        {
            get
            {
                if (_getUserName == null) _getUserName = new RelayCommand(
                    (object o) =>
                    {
                        WelcomeMessageConverter messageConv = new WelcomeMessageConverter(UserName);
                        WelcomeMessage = messageConv.ConvertWelcomeMessage();
                    },
                    (object o) =>
                    {
                        if(String.IsNullOrWhiteSpace(UserName))
                            return false;
                        return true;
                    });
                return _getUserName;
            }
        }
    }
}
