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
            result = string.Empty;

            switch (intent)
            {
                case "LookAtRoom":
                    result = "You see a small light in the distance. Maybe you should [go to] that light.";
                    return true;
                case "GoToLight":
                    if (currentState.TutorialState.NextToLightSwitch)
                    {
                        result = "You are already here. The small amout of light seems to be coming from a light switch. Maby you should [use] is.";
                    }
                    else
                    {
                        if (currentState.TutorialState.IsFree)
                        {
                            result = "As you slowly make your way through the darkness you realiste that the small light is a lightswitch.";
                            currentState.TutorialState.NextToLightSwitch = true;
                        }
                        else
                        {
                            result = "You notice that you can not move because you are enchained. But you feel a key next to you. Maybe you should [take] it.";
                        }
                    }
                    return true;
                case "TakeKey":
                    result = "You took the key. Maybe you can [use] it to free yourself.";
                    currentState.Inventory.Add("Padlock key");
                    return true;
                case "UseKey":
                    if (currentState.TutorialState.IsFree)
                    {
                        result = "You are already free. What are you waiting for? Go to that small light.";
                    }
                    else
                    {
                        if (currentState.Inventory.Contains("Padlock key"))
                        {
                            result = "You freed yourself and can move around freely. It's still dark though and you only see a small ligth";
                            currentState.TutorialState.IsFree = true;
                        }
                        else
                        {
                            result = "You don't have the key to free yourself.";
                        }
                    }
                    return true;
                case "UseLightSwitch":
                    if (currentState.TutorialState.LightOn)
                    {
                        result = "It's not a good idea to turn the light back off again.";
                    }
                    else
                    {
                        if (currentState.TutorialState.NextToLightSwitch)
                        {
                            result = "The room is filled with light. The first thing you notice is the big wardrobe infront of you. Next to that you see a bed with a little nightstand. On the ground you see a picture, but you can not see whats on it from the distance. There is also a radio, maybe it still works? As you look behind you, you see a big steel door. What do you want to check out first?";
                            currentState.TutorialState.LightOn = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
            }
            return false;
        }
    }
}
