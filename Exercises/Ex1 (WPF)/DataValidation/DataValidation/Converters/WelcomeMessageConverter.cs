using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidation.Converters
{
    public class WelcomeMessageConverter
    {
        public string userName;
        public int userAge;

        public WelcomeMessageConverter(string name, string age)
        {
            this.userName = name;
            this.userAge = int.Parse(age);
        }

        public string ConvertedWelcomeMessage()
        {
            if (userAge >= 18)
                return $"Witaj {userName}, Wiek: {userAge}, Pełnoletni.";
            return $"Witaj {userName}, Wiek: {userAge}.";
        }
    }
}
