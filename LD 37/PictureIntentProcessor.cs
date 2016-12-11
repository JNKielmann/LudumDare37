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
            if (intent.IsInvalidThing)
            {
                return null;
            }
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingPicture:
                            return "The picture shows a happy family. The people on the picture seem familiar but you can't remeber who they are.";
                        case Intent.ThingFloor:
                            if (!currentState.PictureState.PickedUpPicture)
                            {
                                return "There is a {picture} on the {floor}.";
                            }
                            else
                            {
                                return "You see a small {crack} in the {floor}.";
                            }
                        case Intent.ThingCrackInFloor:
                            if (!currentState.PictureState.PickedUpPicture)
                            {
                                return null;
                            }
                            else
                            {
                                return "You see a small {piece of paper}";
                            }
                    }
                    break;
                case Intent.ActionTake:
                    switch (intent.Thing)
                    {
                        case Intent.ThingPicture:
                            if (currentState.PictureState.PickedUpPicture)
                            {
                                return "You already moved the {picture}. You dont need to pick it up again.";
                            }
                            else
                            {
                                currentState.PictureState.PickedUpPicture = true;
                                return "As you [pick up] the {picture} you notice something on the {floor}. You put the {picture} aside.";
                            }
                        case Intent.ThingPaper:
                            if (!currentState.PictureState.PickedUpPicture)
                            {
                                return null;
                            }
                            else
                            {
                                if (currentState.Inventory.Contains(Inventory.PieceOfPaperBlue))
                                {
                                    return "You already picked up the {paper}. Try [look at] {inventory} to read it again.";
                                }
                                else
                                {
                                    currentState.Inventory.Add(Inventory.PieceOfPaperBlue);
                                    return "You picked up the small {piece of paper} and put it into your {inventory} to [look at] it again later. There is a 4 written on it with blue ink.";
                                }
                            }
                    }
                    break;
            }
            return null;
        }
    }
}
