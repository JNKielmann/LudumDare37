﻿using System;
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
            if(string.IsNullOrEmpty(intent.Thing))
            {
                return null;
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
                    return Strings.Get(Strings.Keys.Tutorial_Use_LightSwitch_LightOff);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
