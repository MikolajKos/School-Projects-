using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.Validator
{
    public class SecondValidatorsClass
    {
        public List<string> errorList = new List<string>();
        public List<string> countErrors = new List<string>();
        public string firstName;
        public string userAge;

        public string firstNameRegex = @"^[a-zA-Z]*$";
        public string ageRegex = @"^[1-9]*$";

        public SecondValidatorsClass(string name, string age, List<string> infoList)
        {
            this.errorList = infoList;
            this.firstName = name;
            this.userAge = age;
        }

        //Runs all validation methods and returns list of errors
        //Param1: welcomeMessage - if no error occured string will display name and age of user
        public List<string> FullValidation()
        {
            #region Add errorList messages
                IsNameStringNotNull();
                IsAgeStringNotNull();
                IsNameStringCorrect();
                IsAgeStringCorrect();
                CheckNameLenght();
                CheckAgeValue();
            #endregion
            
            return errorList;
        }


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
            if (Regex.IsMatch(firstName, firstNameRegex))
                return null;
            errorList.Add("*Name string is incorrect");
            return errorList;
        }

        //Check if userAge string meets regex requirements
        private List<string> IsAgeStringCorrect()
        {
            if (Regex.IsMatch(userAge, ageRegex))
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
