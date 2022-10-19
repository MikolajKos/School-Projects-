using DataValidation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.MVVM.Models
{
    public class MainModel
    {
        public string firstName = "";
        public string userAge = "";
        public string welcomeMessage = "";

        
        //Assigns errorList value from SecondValidationClass to errorList in MainModel
        public List<string> AssignErrorList()
        {
            List<string> errorList = new List<string>();

            SecondValidatorsClass mySecondValidator = new SecondValidatorsClass(firstName, userAge, errorList);
            errorList = mySecondValidator.FullValidation();

            return errorList;
        }

        public string InfoMessage(List<string> listOfErrors)
        {
            if (listOfErrors.Count == 0)
                return welcomeMessage = $"Welcome! Name: {firstName}, Age: {userAge}.";
            return welcomeMessage = String.Empty;
        }
    }
}