using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class WardrobeIntentProcessor
    {
        static public string Process(Intent intent, State currentState)
        {
            if (intent.IsInvalidThing)
            {
                return null;
            }
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingWardrobe:
                            if (currentState.WardrobeState.IsOpen)
                            {
                                return "There are lots of old clothes. Maybe you can [search] for something useful.";
                            }
                            else
                            {
                                return "It is a big closed {wardobe}. Do you dare to [open] it?";
                            }
                    }
                    break;
                case Intent.ActionOpen:
                    switch (intent.Thing)
                    {
                        case Intent.ThingWardrobe:
                            if (currentState.WardrobeState.IsOpen)
                            {
                                return "You already opended the {wardrobe}";
                            }
                            else
                            {
                                currentState.WardrobeState.IsOpen = true;
                                return @"You slowly open the door and expect the worst
.³.³.³
Fortunately there are only some old clothes. 
Maybe you can [search] for something useful.";
                            }
                    }
                    break;
                case Intent.ActionSearch:
                    switch (intent.Thing)
                    {
                        case Intent.ThingWardrobe:
                        case Intent.ThingClothes:
                            if (currentState.WardrobeState.IsOpen)
                            {
                                if (currentState.Inventory.Contains(Inventory.PieceOfPaperGreen))
                                {
                                    return "You examin the clothes again but find nothing useful.";
                                }
                                else
                                {
                                    currentState.Inventory.Add(Inventory.PieceOfPaperGreen);
                                    currentState.Inventory.Add(Inventory.UnknownKey);
                                    return @"You found a {piece of paper} with a 1 written on it in green ink. 
Moreover you found a {key}. 
You put them both into your {inventory}. 
That was easier than expected...";
                                }
                            }
                            break;
                    }
                    break;
            }
            return null;
        }
    }
}
