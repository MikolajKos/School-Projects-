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
        public List<string> FullValidation(out string welcomeMessage)
        {
            #region Add errorList messages
                IsNameStringNotNull();
                IsAgeStringNotNull();
                IsNameStringCorrect();
                IsAgeStringCorrect();
                CheckNameLenght();
                CheckAgeValue();
            #endregion
            
            welcomeMessage = InfoMessage();
            return errorList;
        }

        //Returns welcome string with user's name and age
        private string InfoMessage()
        {
            string welcome = $"Welcome! Name: {firstName}, Age: {userAge}.";
            
            if(countErrors.Count == 0)
                return welcome;
            return String.Empty;
        }

        //Check if firstName string is empty
        private bool IsNameStringNotNull()
        {
            if (!(firstName == String.Empty))
                return true;

            countErrors.Add("");
            errorList.Add("*Please enter your name");
            return false;
        }

        //Check if userAge string is empty
        private bool IsAgeStringNotNull()
        {
            if (!(userAge == String.Empty))
                return true;

            countErrors.Add("");
            errorList.Add("*Please enter your age");
            return false;
        }

        //Check if firstName string meets regex requirements
        private bool IsNameStringCorrect()
        {
            if (Regex.IsMatch(firstName, firstNameRegex))
                return true;

            countErrors.Add("");
            errorList.Add("*Name string is incorrect");
            return false;
        }

        //Check if userAge string meets regex requirements
        private bool IsAgeStringCorrect()
        {
            if (Regex.IsMatch(userAge, ageRegex))
                return false;

            countErrors.Add("");
            errorList.Add("*Age string is incorrect");
            return true;
        }

        //Checks if firstName string length is not bigger than 50
        private bool CheckNameLenght()
        {
            if (!(firstName.Length > 50))
                return true;

            countErrors.Add("");
            errorList.Add("*Entered name is too long");
            return false;
        }

        //Checks if userAge int value is not bigger than 150
        private bool CheckAgeValue()
        {
            if (int.TryParse(userAge, out int age))
            {
                if (age > 150)
                {
                    countErrors.Add("");
                    errorList.Add("*Entered age value is too big");
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
