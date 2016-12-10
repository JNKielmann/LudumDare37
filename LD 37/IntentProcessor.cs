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
                case Location.Picture:
                    hadAnswer = PictureIntentProcessor.Process(intent, currentState, out answer);
                    break;
                case Location.Exit:
                    break;
            }
            if (hadAnswer)
            {
                return answer;
            }
            else
            {
                if (currentState.TutorialState.LightOn)
                {
                    switch (intent)
                    {
                        case "GoToBed":
                            currentState.Location = Location.Bed;
                            return "You are now next to the Bed.";
                        case "GoToWardrobe":
                            currentState.Location = Location.Wardrobe;
                            return "You are now next to the Wardrobe.";
                        case "GoToRadio":
                            currentState.Location = Location.Radio;
                            return "You are now next to the Radio.";
                        case "GoToPicture":
                            currentState.Location = Location.Picture;
                            return "You are now next to the Picture.";
                        case "GoToExit":
                            currentState.Location = Location.Exit;
                            return "You are now next to the Picture.";
                    }
                }
            }

            return Strings.Get(Strings.Keys.UnknownIntent);
        }

    }
}
