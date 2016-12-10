using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class IntentProcessor
    {
        public string Process(Intent intent, State currentState)
        {
            string answer = null;
            switch (currentState.Location)
            {
                case Location.Tutorial:
                    answer = TutorialIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Door:
                    answer = DoorIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Picture:
                    answer = PictureIntentProcessor.Process(intent, currentState);
                    break;
            }
            if (answer != null)
            {
                return answer;
            }
            else
            {
                switch (intent.Action)
                {
                    case Intent.ActionGoto:
                        if (currentState.TutorialState.LightOn)
                        {

                            switch (intent.Thing)
                            {
                                case Intent.ThingBed:
                                    currentState.Location = Location.Bed;
                                    return "You are now next to the Bed.";
                                case Intent.ThingWardrobe:
                                    currentState.Location = Location.Wardrobe;
                                    return "You are now next to the Wardrobe.";
                                case Intent.ThingRadio:
                                    currentState.Location = Location.Radio;
                                    return "You are now next to the Radio.";
                                case Intent.ThingPicture:
                                    currentState.Location = Location.Picture;
                                    return "You are now next to the Picture.";
                                case Intent.ThingDoor:
                                    currentState.Location = Location.Door;
                                    return "You are now next to the Door.";
                            }
                        }
                        break;
                    case Intent.ActionLookAt:
                        switch (intent.Thing)
                        {
                            case Intent.ThingFloor:
                                return "There is nothing on the floor";
                        }
                        break;
                }

            }

            return Strings.Get(Strings.Keys.Unknown_Intent);
        }

    }
}
