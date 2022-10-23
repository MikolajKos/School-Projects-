using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidation.Converters
{
    public class ErrorListConverter
    {
        public List<string> errorList = new List<string>();

        public ErrorListConverter(List<string> errors)
        {
            this.errorList = errors;
        }


        public bool ErrorsWereCount(out List<string> listOfErrors)
        {
            AsignList(out listOfErrors);
            return CountErrors();
        }

        //If errors occured method will return false
        private bool CountErrors()
        {
            if (errorList.Count > 0)
                return false;
            return true;
        }

        //Asigns list with out parameter to let validation return list; 
        private void AsignList(out List<string> myList)
        {
            myList = errorList;
        }
    }
}
