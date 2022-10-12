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
        
        
        public string firstNameRegex = @"^[a-zA-Z]*$";
        public string ageRegex = @"^[1-9]*$";

        

        public List<string> ValidateInputData()
        {
            List<string> errorList = new List<string>();
            errorList.Clear();

            SecondValidatorsClass mySecondValidator = new SecondValidatorsClass(firstName, userAge, errorList);
            mySecondValidator.FullValidation(out errorList);

            return errorList;
        }

        public string InfoMessage(List<string> listOfErrors)
        {
            if (listOfErrors.Count == 0)
                return welcomeMessage = $"Welcome! Name: {firstName}, Age: {userAge}.";
            return String.Empty;
        }
    }
}

/*ThirdValidatorsClass myThirdValidator = new ThirdValidatorsClass(firstName, userAge, errorList);
myThirdValidator.FullValidation(out welcomeMessage);*/

/*SecondValidatorsClass mySecondValidator = new SecondValidatorsClass(firstName, userAge, errorList);
mySecondValidator.FullValidation(out welcomeMessage);*/

/*Validators myValidator = new Validators(firstName, userAge, errorList);
myValidator.FullValidation(out errorList);*/





/*            List<string> errorList = new List<string>();
            errorList.Clear();

            if (firstName == "" || userAge == "")
            {
                if (firstName == String.Empty)
                    errorList.Add("*Please enter your name.");
                if (userAge == String.Empty)
                    errorList.Add("*Please enter your age.");
            }
            else if (firstName != "" || userAge != "")
            {
                if (!Regex.IsMatch(firstName, firstNameRegex))
                    errorList.Add("*Name string is incorrect.");
                if (!Regex.IsMatch(userAge, ageRegex))
                    errorList.Add("*Age string is incorrect");

                if (firstName.Length > 50)
                    errorList.Add("*Entered name is too long.");

                if(int.TryParse(userAge, out int intAge))
                {
                    if (intAge > 150)
                        errorList.Add("*Entered age value is too big.");
                }

            }
            
            if (errorList.Count == 0)
            {
                errorList.Add($"Welcome {firstName}, Age: {userAge}."); ;
            }

            return errorList;*/