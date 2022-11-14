using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyBinding.Converters
{
    class WelcomeMessageConverter
    {
        public string userName;

        public WelcomeMessageConverter(string name)
        {
            this.userName = name;
        }

        public string ConvertWelcomeMessage()
        {
            string welcomeMessage =  $"Welcome {userName}!";
            return welcomeMessage;
        }
    }
}
