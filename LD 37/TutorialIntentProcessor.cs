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
            if (currentState.TutorialState.EyesAreClosed)
            {
                if ((intent.Action == Intent.ActionOpen || intent.Action == Intent.ActionUse)
                    && intent.Thing == Intent.ThingEyes)
                {
                    currentState.TutorialState.EyesAreClosed = false;
                    return @"""Damn it!"" you shout as you realize that it is still dark.
However it's not pitch black so you are able to see the
silhouettes of some objects.
Maybe you should [look around] to check if you can spot
something that might help.";
                }
                return "Before you do anything else, it would be a good idea to [open] your {eyes}.";
            }

            switch (intent.Action)
            {
                case Intent.ActionLookAtRoom:
                    return Strings.Get(Strings.Keys.Tutorial_LookAtRom);
                case Intent.ActionGoto:
                    if(!currentState.TutorialState.IsFree)
                    {
                        return Strings.Get(Strings.Keys.Tutorial_Goto_Light_IsEnchained);
                    }
                    switch(intent.Thing)
                    {
                        case Intent.ThingLight:
                            if (currentState.TutorialState.NextToLightSwitch)
                            {
                                return Strings.Get(Strings.Keys.Tutorial_Goto_Light_NextTo);
                            }
                            else
                            {
                                currentState.TutorialState.NextToLightSwitch = true;
                                return Strings.Get(Strings.Keys.Tutorial_Goto_Light_IsFree);
                            }
                    }
                    break;
                case Intent.ActionTake:
                    switch (intent.Thing)
                    {
                        case Intent.ThingKey:
                            if (currentState.Inventory.Contains(Inventory.PadlockKey))
                            {
                                return Strings.Get(Strings.Keys.Tutorial_Take_Key_AlreadyInInventory);
                            }
                            else
                            { 
                                currentState.Inventory.Add(Inventory.PadlockKey);
                                return Strings.Get(Strings.Keys.Tutorial_Take_Key);
                            }
                    }
                    break;
                case Intent.ActionPress:
                    switch (intent.Thing)
                    {
                        case Intent.ThingLightSwitch:
                            return HandlePressLightSwitch(currentState);
                    }
                    break;
                case Intent.ActionUse:
                    switch (intent.Thing)
                    {
                        case Intent.ThingKey:
                            if (currentState.TutorialState.IsFree)
                            {
                                return Strings.Get(Strings.Keys.Tutorial_Use_Key_IsFree);
                            }
                            else
                            {
                                if (currentState.Inventory.Contains(Inventory.PadlockKey))
                                {
                                    currentState.TutorialState.IsFree = true;
                                    return Strings.Get(Strings.Keys.Tutorial_Use_Key_IsEnchained_HasKey);
                                }
                                else
                                {
                                    return Strings.Get(Strings.Keys.Tutorial_Use_Key_IsEnchained_HasNoKey);
                                }
                            }
                        case Intent.ThingLightSwitch:
                            return HandlePressLightSwitch(currentState);
                    }
                    break;            
            }
            return null;
        }

        static string HandlePressLightSwitch(State currentState)
        {
            if (currentState.TutorialState.LightOn)
            {
                return Strings.Get(Strings.Keys.Tutorial_Use_LightSwitch_LightOn);
            }
            else
            {
                if (currentState.TutorialState.NextToLightSwitch)
                {
                    currentState.TutorialState.LightOn = true;
                    return Strings.Get(Strings.Keys.Tutorial_Use_LightSwitch_LightOff) + "\n" + Strings.Get(Strings.Keys.Room_Description);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
