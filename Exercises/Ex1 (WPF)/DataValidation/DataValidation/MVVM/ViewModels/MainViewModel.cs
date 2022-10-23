using DataValidation.Converters;
using DataValidation.Core;
using DataValidation.MVVM.Models;
using DataValidation.Validator;
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

        private string _firstNameTb = "";
        public string FirstNameTb
        {
            get
            {
                return _firstNameTb;
            }
            set
            {
                _firstNameTb = value;
                onPropertyChanged(nameof(FirstNameTb));
            }
        }

        private string _ageTb = "";
        public string AgeTb
        {
            get
            {
                return _ageTb;
            }
            set
            {
                _ageTb = value;
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

        private string _welcomeMessage;
        public string WelcomeMessage 
        {
            get
            {
                return _welcomeMessage;
            }
            set
            {
                _welcomeMessage = value;
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
                        ValidatorsClass dbOperations = new ValidatorsClass(FirstNameTb, AgeTb);

                        if (!dbOperations.FullValidation(out model.listOfErrors))
                        {
                            ErrorMessageTb = model.listOfErrors;
                            WelcomeMessage = String.Empty;
                        }
                        else
                        {
                            WelcomeMessageConverter messageConverter = new WelcomeMessageConverter(FirstNameTb, AgeTb);
                            WelcomeMessage = messageConverter.ConvertedWelcomeMessage();
                            ErrorMessageTb = model.listOfErrors;
                        }
                    },
                    (object o) =>
                    {
                        return true;
                    });
                return _validateInput;
            }
        }
    }
}
