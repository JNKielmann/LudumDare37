using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class TutorialIntentProcessor 
    {
        static public bool Process(string intent, State currentState, out string result)
        {
            if (intent == "LookAround")
            {
                result =  "You see a small light in the distance";
                return true;
            }
            result = string.Empty;
            return false;
        }
    }
}
