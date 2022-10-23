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
            ErrorListConverter listConverter = new ErrorListConverter(errorList);

            #region Runs all validation methods
            IsNameStringNotNull();
            IsAgeStringNotNull();
            IsNameStringCorrect();
            IsAgeStringCorrect();
            CheckNameLenght();
            CheckAgeValue();
            #endregion

            return listConverter.ErrorsWereCount(out myErrors);
        }


        //You can add validation methods depending on your needs


        //Check if firstName string is empty
        private List<string> IsNameStringNotNull()
        {
            if (!(firstName == String.Empty))
                return null;
            errorList.Add("*Please enter your name");
            return errorList;
        }

        //Check if userAge string is empty
        private List<string> IsAgeStringNotNull()
        {
            if (!(userAge == String.Empty))
                return null;
            errorList.Add("*Please enter your age");
            return errorList;
        }

        //Check if firstName string meets regex requirements
        private List<string> IsNameStringCorrect()
        {
            if (Regex.IsMatch(firstName, model.firstNameRegex))
                return null;
            errorList.Add("*Name string is incorrect");
            return errorList;
        }

        //Check if userAge string meets regex requirements
        private List<string> IsAgeStringCorrect()
        {
            if (Regex.IsMatch(userAge, model.ageRegex))
                return null;
            errorList.Add("*Age string is incorrect");
            return errorList;
        }

        //Checks if firstName string length is not bigger than 50
        private List<string> CheckNameLenght()
        {
            if (!(firstName.Length > 50))
                return null;
            errorList.Add("*Entered name is too long");
            return errorList;
        }

        //Checks if userAge int value is not bigger than 150
        private List<string> CheckAgeValue()
        {
            if (int.TryParse(userAge, out int age))
            {
                if (age > 150)
                {
                    errorList.Add("*Entered age value is too big");
                    return errorList;
                }
                return null;
            }
            return errorList;
        }
    }
}


/*private List<string> DontSwear()
{
    if (!(firstName == "Fuck"))
        return null;
    errorList.Add("*Don't swear!");
    return errorList;
}*/