using DataValidation.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataValidation.Validator
{
    public class NameValidation
    {
        public string firstName;
        public List<string> errorList = new List<string>();
        MainModel model = new MainModel();

        public NameValidation(string name, List<string> getErrors)
        {
            this.firstName = name;
            this.errorList = getErrors;
        }

        public List<string> FullValidationName()
        {
            IsNameStringNotNull();
            IsNameStringCorrect();
            CheckNameLenght();

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

        //Check if firstName string meets regex requirements
        private List<string> IsNameStringCorrect()
        {
            if (Regex.IsMatch(firstName, model.firstNameRegex))
                return null;
            errorList.Add("*Name string is incorrect");
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
    }
}
