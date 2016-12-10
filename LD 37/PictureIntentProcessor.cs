using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    class PictureIntentProcessor
    {
        static public string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingPicture:
                            return "The picture shows ....";
                        case Intent.ThingFloor:
                            if (!currentState.Inventory.Contains("Picture"))
                            {
                                return null;
                            }
                            else
                            {
                                return "You see a small crack in the floor.";
                            }
                        case Intent.ThingCrackInFloor:
                            if (!currentState.Inventory.Contains("Picture"))
                            {
                                return null;
                            }
                            else
                            {
                                return "You see a small piece of paper";
                            }
                    }
                    break;
                case Intent.ActionTake:
                    switch (intent.Thing)
                    {
                        case Intent.ThingPicture:
                            if (currentState.Inventory.Contains("Picture"))
                            {
                                return "You already moved the Picture. You dont need to pick it up again.";
                            }
                            else
                            {

                                return "As you pick up the picture you notice something on the floor. You put the picture aside.";
                            }
                        case Intent.ThingPaper:
                            if (!currentState.Inventory.Contains("Picture"))
                            {
                                return null;
                            }
                            else
                            {
                                currentState.Inventory.Add("Piece of paper with a 4 in blue ink.");
                                return "You picked up the small piec of paper. There is a 4 written on it with blue ink.";
                            }
                    }
                    break;
            }
            return null;
        }
    }
}
