using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    class PictureIntentProcessor
    {
        static public bool Process(string intent, State currentState, out string result)
        {
            result = string.Empty;

            switch (intent)
            {
                case "LookAtPicture":
                    result = "The picture shows ....";
                    return true;
                case "TakePicture":
                    if (currentState.Inventory.Contains("Picture"))
                    {
                        result = "You already picked up the Picture";
                    }
                    else
                    {
                        result = "As you pick up the picture you notice something on the floor.";
                    }
                    currentState.Inventory.Add("Picture");
                    return true;
                case "LookAtFloor":
                    if (!currentState.Inventory.Contains("Picture"))
                    {
                        return false;
                    }
                    else
                    {
                        result = "You see a small crack in the floor.";
                    }
                    return true;
                case "LookAtCrackInFloor":
                    if (!currentState.Inventory.Contains("Picture"))
                    {
                        return false;
                    }
                    else
                    {
                        result = "You see a small piece of paper";
                    }
                    return true;
                case "TakePaper":
                    if (!currentState.Inventory.Contains("Picture"))
                    {
                        return false;
                    }
                    else
                    {
                        result = "You picked up the small piec of paper. There is a 4 written on it with blue ink.";
                        currentState.Inventory.Add("Piece of paper with a 4 in blue ink.");
                    }
                    return true;

            }
            return false;
        }
    }
}
