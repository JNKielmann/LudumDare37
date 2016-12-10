using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class IntentProcessor
    {
        public string Process(string intent, State currentState)
        {
            string answer = "";
            bool hadAnswer = false;
            switch (currentState.Location)
            {
                case Location.Tutorial:
                    hadAnswer = TutorialIntentProcessor.Process(intent, currentState, out answer);
                    break;
                case Location.Exit:
                    break;
            }
            if(hadAnswer)
            {
                return answer;
            }

            return Strings.Get(Strings.Keys.UnknownIntent);
        }

    }
}
