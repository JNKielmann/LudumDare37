using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class TutorialIntentProcessor
    {
        static public string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAtRoom:
                    return "You see a small light in the distance. Maybe you should [go to] that light.";
                case Intent.ActionGoto:
                    switch(intent.Thing)
                    {
                        case Intent.ThingLight:
                            if (currentState.TutorialState.NextToLightSwitch)
                            {
                                return "You are already here. The small amout of light seems to be coming from a light switch. Maby you should [use] is.";
                            }
                            else
                            {
                                if (currentState.TutorialState.IsFree)
                                {
                                    currentState.TutorialState.NextToLightSwitch = true;
                                    return "As you slowly make your way through the darkness you realiste that the small light is a lightswitch.";
                                }
                                else
                                {
                                    return "You notice that you can not move because you are enchained. But you feel a key next to you. Maybe you should [take] it.";
                                }
                            }
                    }
                    break;
                case Intent.ActionTake:
                    switch (intent.Thing)
                    {
                        case Intent.ThingKey:
                            currentState.Inventory.Add("Padlock key");
                            return "You took the key. Maybe you can [use] it to free yourself.";
                    }
                    break;
                case Intent.ActionUse:
                    switch (intent.Thing)
                    {
                        case Intent.ThingKey:
                            if (currentState.TutorialState.IsFree)
                            {
                                return "You are already free. What are you waiting for? Go to that small light.";
                            }
                            else
                            {
                                if (currentState.Inventory.Contains("Padlock key"))
                                {
                                    currentState.TutorialState.IsFree = true;
                                    return "You freed yourself and can move around freely. It's still dark though and you only see a small ligth";
                                }
                                else
                                {
                                    return "You don't have the key to free yourself.";
                                }
                            }
                        case Intent.ThingLightSwitch:
                            if (currentState.TutorialState.LightOn)
                            {
                                return "It's not a good idea to turn the light back off again.";
                            }
                            else
                            {
                                if (currentState.TutorialState.NextToLightSwitch)
                                {
                                    currentState.TutorialState.LightOn = true;
                                    return "The room is filled with light. The first thing you notice is the big wardrobe infront of you. Next to that you see a bed with a little nightstand. On the ground you see a picture, but you can not see whats on it from the distance. There is also a radio, maybe it still works? As you look behind you, you see a big steel door. What do you want to check out first?";
                                }
                                else
                                {
                                    return null;
                                }
                            }
                    }
                    break;            
            }
            return null;
        }
    }
}
