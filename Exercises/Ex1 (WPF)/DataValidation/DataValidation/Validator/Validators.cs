using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.Validator
{
    public class Validators
    {
        public List<string> errorList = new List<string>();
        public string firstName;
        public string userAge;

        public string firstNameRegex = @"^[a-zA-Z]*$";
        public string ageRegex = @"^[1-9]*$";

        public Validators(string name, string age, ref List<string> infoList)
        {
            this.errorList = infoList;
            this.firstName = name;
            this.userAge = age;
        }

        public bool FullValidation()
        {
            List<string> CountErrors = new List<string>();

            #region Add errorList messages
            if (!IsNameStringNotNull())
            {
                errorList.Add("*Please enter your name");
                CountErrors.Add("NewError");
            }
                
            if (!IsAgeStringNotNull())
            {
                errorList.Add("*Please enter your age");
                CountErrors.Add("NewError");
            }

            if (!IsNameStringCorrect())
            {
                errorList.Add("*Name string is incorrect");
                CountErrors.Add("NewError");
            }
                
            if (!IsAgeStringCorrect())
            {
                errorList.Add("*Age string is incorrect");
                CountErrors.Add("NewError");
            }

            if (!CheckNameLenght())
            {
                errorList.Add("*Entered name is too long");
                CountErrors.Add("NewError");
            }

            if (!CheckAgeValue())
            {
                errorList.Add("*Entered age value is too big");
                CountErrors.Add("NewError");
            }
            #endregion

            if (CountErrors.Count == 0)
                return true;
            return false;
        }

        //Check if firstName string is empty
        private bool IsNameStringNotNull()
        {
            if (firstName == String.Empty)
                return false;
            return true;
        }

        //Check if userAge string is empty
        private bool IsAgeStringNotNull()
        {
            if (userAge == String.Empty)
                return false;
            return true;
        }

        //Check if firstName string meets regex requirements
        private bool IsNameStringCorrect()
        {
            if (!Regex.IsMatch(firstName, firstNameRegex))
                return false;
            return true;
        }

        //Check if userAge string meets regex requirements
        private bool IsAgeStringCorrect()
        {
            if (!Regex.IsMatch(userAge, ageRegex))
                return false;
            return true;
        }

        //Checks if firstName string length is not bigger than 50
        private bool CheckNameLenght()
        {
            if (firstName.Length > 50)
                return false;
            return true;
        }

        //Checks if userAge int value is not bigger than 150
        private bool CheckAgeValue()
        {
            if (int.TryParse(userAge, out int age))
            {
                if (age > 150)
                    return false;
                return true;
            }
            return false;
        }
    }
}
