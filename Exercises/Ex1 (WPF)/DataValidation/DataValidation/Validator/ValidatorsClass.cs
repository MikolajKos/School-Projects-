using DataValidation.Converters;
using DataValidation.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.Validator
{
    public class ValidatorsClass
    {
        MainModel model = new MainModel();

        public List<string> errorList = new List<string>();
        public string firstName;
        public string userAge;


        public ValidatorsClass(string name, string age)
        {
            this.firstName = name;
            this.userAge = age;
        }

        //Runs all validation methods and returns list of errors
        //Param1: welcomeMessage - if no error occured string will display name and age of user
        public bool FullValidation(out List<string> myErrors)
        {
            //Passes errorList to count errors and lets push out myErrors 
            ErrorListConverter listConverter = new(errorList);
            NameValidation nameVal = new(firstName, errorList);
            AgeValidation ageVal = new(userAge, errorList);

            #region Runs all validation methods

            nameVal.FullValidationName();
            ageVal.FullAgeValidation();

            #endregion

            return listConverter.ErrorsWereCount(out myErrors);
        }
    }
}