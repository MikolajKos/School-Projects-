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

        public bool FullValidation(out List<string> myList)
        {
            List<string> CountErrors = new List<string>();

            #region Add errorList messages
                IsNameStringNotNull();
                IsAgeStringNotNull();
                IsNameStringCorrect();
                IsAgeStringCorrect();
                CheckNameLenght();
                CheckAgeValue();
            #endregion

            myList = errorList;

            if (CountErrors.Count == 0)
                return true;
            return false;
        }

        //Check if firstName string is empty
        private bool IsNameStringNotNull()
        {
            if (!(firstName == String.Empty))
                return true;

            errorList.Add("*Please enter your name");
            return false;
        }

        //Check if userAge string is empty
        private bool IsAgeStringNotNull()
        {
            if (!(userAge == String.Empty))
                return true;

            errorList.Add("*Please enter your age");
            return false;
        }

        //Check if firstName string meets regex requirements
        private bool IsNameStringCorrect()
        {
            if (Regex.IsMatch(firstName, firstNameRegex))
                return true;

            errorList.Add("*Name string is incorrect");
            return false;
        }

        //Check if userAge string meets regex requirements
        private bool IsAgeStringCorrect()
        {
            if (Regex.IsMatch(userAge, ageRegex))
                return false;

            errorList.Add("*Age string is incorrect");
            return true;
        }

        //Checks if firstName string length is not bigger than 50
        private bool CheckNameLenght()
        {
            if (!(firstName.Length > 50))
                return true;

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
                    errorList.Add("*Entered age value is too big");
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
