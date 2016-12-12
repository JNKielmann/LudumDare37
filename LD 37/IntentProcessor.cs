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
            if (intent.Action == Intent.ActionWTF)
            {
                string easterEgg = EasterEggIntentProcessor.Process(intent, currentState);
                if (easterEgg != null)
                    return easterEgg;
            }

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
                case Location.Radio:
                    answer = RadioIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Bed:
                    answer = BedIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Wardrobe:
                    answer = WardrobeIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Window:
                    answer = WindowIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Trapdoor:
                    answer = TrapdoorIntentProcessor.Process(intent, currentState);
                    break;
            }
            if (answer != null)
                return answer;

            switch (intent.Action)
            {
                case Intent.ActionLookAtRoom:
                    return "You are in a small room that seems to be part of a shed.\n" + Strings.Get(Strings.Keys.Room_Description);
                case Intent.ActionInventory:
                    if (currentState.Inventory.Count == 0)
                    {
                        return "Your inventory is empty. You have not picked up anything.";
                    }
                    string inventoryString = "Your inventory contains:\n";
                    foreach (string item in currentState.Inventory)
                    {
                        inventoryString += "- " + item + "\n";
                    }
                    return inventoryString;
                case Intent.ActionGoto:
                    if (currentState.TutorialState.LightOn)
                    {
                        switch (intent.Thing)
                        {
                            case Intent.ThingBedNightstand:
                            case Intent.ThingBed:
                                if (currentState.Location == Location.Bed)
                                {
                                    return "You are already next to the {bed}.";
                                }
                                else
                                {
                                    currentState.Location = Location.Bed;
                                    return @"You decide to check out the {bed}. 
Next to it there is a {nighstand}.
You also see a little {flyer} lying under the pillow.";
                                }
                            case Intent.ThingWardrobe:
                                if (currentState.Location == Location.Wardrobe)
                                {
                                    return "You are already next to the {wardrobe}.";
                                }
                                else
                                {
                                    currentState.Location = Location.Wardrobe;
                                    return @"You walk over to the {wardrobe}. 
It looks intimidating.
Do you dare to [open] it?";
                                }
                            case Intent.ThingRadio:
                                if (currentState.Location == Location.Radio)
                                {
                                    return "You are already next to the {radio}.";
                                }
                                else
                                {
                                    currentState.Location = Location.Radio;
                                    return "You approach the old {radio}. Some music would be nice.";
                                }
                            case Intent.ThingPicture:
                                if (currentState.Location == Location.Picture)
                                {
                                    return "You are already next to the {picture}.";
                                }
                                else
                                {
                                    currentState.Location = Location.Picture;
                                    return "You are now next to the {picture} on the floor.";
                                }
                            case Intent.ThingDoor:
                                if (currentState.Location == Location.Door)
                                {
                                    return "You are already in front of to the {door}.";
                                }
                                currentState.Location = Location.Door;
                                return @"You turn around and are now in front of the steel {door}. 
Your only way out of here?
Of course the door is locked.
It seems like there is a {keypad} on the {door} to unlock it.
If the keypad works correctly, it could be possible to enter
some kind of code to open the door.";
                            case Intent.ThingWindow:
                                if (currentState.Location == Location.Window)
                                {
                                    return "You are already in front of the {window}.";
                                }
                                currentState.Location = Location.Window;
                                return "You walk towards the {window} to see what you can do from there.";
                            case Intent.ThingTrapdoor:
                                if (currentState.Location == Location.Trapdoor)
                                {
                                    return "You are already in front of the {trapdoor}.";
                                }
                                currentState.Location = Location.Trapdoor;
                                return "You are now in front of the {trapdoor}.";
                        }
                    }
                    if (string.IsNullOrEmpty(intent.Thing))
                    {
                        return "Where do you want to [go]?";
                    }
                    else
                    {
                        return $"I don't know where {{{intent.Thing}}} is.";
                    }
                case Intent.ActionLookAt:
                    if (currentState.TutorialState.LightOn)
                    {
                        switch (intent.Thing)
                        {
                            case Intent.ThingBedNightstand:
                            case Intent.ThingBed:
                                return "It's an old {bed} with a {nightstand}. You should probably [go to] the {bed}.";
                            case Intent.ThingWardrobe:
                                return "It's a big {wardrobe}. [Go to] it!";
                            case Intent.ThingRadio:
                                return "You see the old {radio} across the room.";
                            case Intent.ThingPicture:
                                return "There is a {picture} on the floor you should [go to]";
                            case Intent.ThingDoor:
                                return "A massive steel {door}. Is this the way out?";
                            case Intent.ThingFloor:
                                return "There is nothing on the floor.";
                        }
                    }
                    if (string.IsNullOrEmpty(intent.Thing))
                    {
                        return "What do you want to [look at]?";
                    }
                    else
                    {
                        return $"Right now you can't see {{{intent.Thing}}}...";
                    }
                case Intent.ActionTake:
                    if (string.IsNullOrEmpty(intent.Thing))
                    {
                        return "What do you want to [take]?";
                    }
                    else
                    {
                        return $"There is no {{{intent.Thing}}} you could pick up.";
                    }
                case Intent.ActionUse:
                    if (string.IsNullOrEmpty(intent.Thing))
                    {
                        return "What do you want to [use]?";
                    }
                    else
                    {
                        return $"Right now you can't use {{{intent.Thing}}}.";
                    }
            }

            return Strings.Get(Strings.Keys.Unknown_Intent);
        }

    }
}
