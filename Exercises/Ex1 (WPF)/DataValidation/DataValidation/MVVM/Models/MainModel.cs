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
        
        
        public string firstNameRegex = @"^[a-zA-Z]*";
        public string ageRegex = @"^[1-9]*";

        

        public List<string> ValidateInputData()
        {
            List<string> errorList = new List<string>();
            errorList.Clear();

            if(firstName == String.Empty || userAge == String.Empty)
            {
                if (firstName == String.Empty)
                    errorList.Add("*Please enter your name.");
                if (userAge == String.Empty)
                    errorList.Add("*Please enter your age.");
            }
            else
            {
                if (!Regex.IsMatch(firstName, firstNameRegex))
                    errorList.Add("*Name string is incorrect.");
                if (!Regex.IsMatch(userAge, ageRegex))
                    errorList.Add("*Age string is incorrect");

                if (firstName.Length > 50)
                    errorList.Add("Entered name is too long.");
                if (userAge.Length > 50)
                    errorList.Add("Entered age is too long.");

            }

            return errorList;
        }
    }
}
