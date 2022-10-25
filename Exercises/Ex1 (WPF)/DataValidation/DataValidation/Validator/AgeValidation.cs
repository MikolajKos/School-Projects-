using DataValidation.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.Validator
{
    public class AgeValidation
    {
        public string userAge;
        public List<string> errorList = new List<string>();
        MainModel model = new MainModel();

        public AgeValidation(string age, List<string> getErrors)
        {
            this.userAge = age;
            this.errorList = getErrors;
        }

        public List<string> FullAgeValidation()
        {
            IsAgeStringNotNull();
            IsAgeStringCorrect();
            CheckAgeValue();

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

        //Check if userAge string meets regex requirements
        private List<string> IsAgeStringCorrect()
        {
            if (Regex.IsMatch(userAge, model.ageRegex))
                return null;
            errorList.Add("*Age string is incorrect");
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
