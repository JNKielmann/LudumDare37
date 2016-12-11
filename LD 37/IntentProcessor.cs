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
                case Location.Radio:
                    answer = RadioIntentProcessor.Process(intent, currentState);
                    break;
                case Location.Wardrobe:
                    answer = WardrobeIntentProcessor.Process(intent, currentState);
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
                    case Intent.ActionInventory:
                        if (currentState.Inventory.Count == 0)
                        {
                            return "Your inventory is empty. You have not picked up anything.";
                        }
                        string inventoryString = "Your inventory contains:\n";
                        foreach (string item in currentState.Inventory)
                        {
                            inventoryString += "- " + item;
                        }
                        return inventoryString;
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
                        if (string.IsNullOrEmpty(intent.Thing))
                        {
                            return "Where do you want to [go]?";
                        }
                        else
                        {
                            return $"I don't know where {{{intent.Thing}}} is.";
                        }

                        break;
                    case Intent.ActionLookAt:
                        if (currentState.TutorialState.LightOn)
                        {
                            switch (intent.Thing)
                            {
                                case Intent.ThingBed:
                                    return "It's an old {bed} with a {nightstand}. You should probably check it out.";
                                case Intent.ThingWardrobe:
                                    return "It's a big {wardrobe}. [Go to] it!";
                                case Intent.ThingRadio:
                                    return "You see the old {radio} across the room.";
                                case Intent.ThingPicture:
                                    return "There is a {picture} on the floor you should [check out]";
                                case Intent.ThingDoor:
                                    return "A massive steel {door}. Is this the way out?";
                            }
                        }
                        if (string.IsNullOrEmpty(intent.Thing))
                        {
                            return "What do you want to [look at]?";
                        }
                        else
                        {
                            return $"Right now you cann't see {{{intent.Thing}}}...";
                        }
                        switch (intent.Thing)
                        {
                            case Intent.ThingFloor:
                                return "There is nothing on the floor.";
                        }
                        break;
                    case Intent.ActionTake:
                        if (string.IsNullOrEmpty(intent.Thing))
                        {
                            return "What do you want to [take]?";
                        }
                        else
                        {
                            return $"There is no {{{intent.Thing}}} you could pick up.";
                        }
                        break;
                    case Intent.ActionUse:
                        if (string.IsNullOrEmpty(intent.Thing))
                        {
                            return "What do you want to [use]?";
                        }
                        else
                        {
                            return $"Right now you cann't use {{{intent.Thing}}}.";
                        }
                        break;
                }

            }

            return Strings.Get(Strings.Keys.Unknown_Intent);
        }

    }
}
