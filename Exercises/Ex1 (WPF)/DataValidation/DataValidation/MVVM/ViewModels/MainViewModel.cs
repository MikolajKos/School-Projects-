using DataValidation.Core;
using DataValidation.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataValidation.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        MainModel model = new MainModel();

        public string FirstNameTb
        {
            get
            {
                return model.firstName;
            }
            set
            {
                model.firstName = value;
                onPropertyChanged(nameof(FirstNameTb));
            }
        }

        public string AgeTb
        {
            get
            {
                return model.userAge;
            }
            set
            {
                model.userAge = value;
                onPropertyChanged(nameof(AgeTb));
            }
        }

        private List<string> _errorMessageTb;
        public List<string> ErrorMessageTb 
        {
            get
            {
                return _errorMessageTb;
            }
            set
            {
                _errorMessageTb = value;
                onPropertyChanged(nameof(ErrorMessageTb));
            }
        }

        public string WelcomeMessage 
        {
            get
            {
                return model.welcomeMessage;
            }
            set
            {
                model.welcomeMessage = value;
                onPropertyChanged(nameof(WelcomeMessage));
            }
        }



        private ICommand _validateInput = null;

        public ICommand ValidateInput
        {
            get
            {
                if (_validateInput == null) _validateInput = new RelayCommand(
                    (object o) =>
                    {
                        ErrorMessageTb = model.ValidateInputData();
                        
                        onPropertyChanged(nameof(ValidateInput), nameof(FirstNameTb), nameof(AgeTb), nameof(WelcomeMessage));
                    },
                    (object o) =>
                    {
/*                        if (FirstNameTb == String.Empty || AgeTb == String.Empty)
                        {
                            return false;
                        }
                        else*/ return true;
                    });
                return _validateInput;
            }
        }
    }
}
