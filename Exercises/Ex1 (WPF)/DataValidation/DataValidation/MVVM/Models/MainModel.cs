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
        public List<string> listOfErrors = new List<string>();
        public string firstNameRegex = @"^[a-zA-Z]*$";
        public string ageRegex = @"^[1-9]*$";
    }
}