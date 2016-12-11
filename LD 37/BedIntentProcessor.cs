using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class BedIntentProcessor
    {
        public static string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingBed:
                            return @"You are standing in front of an old {bed}.
The sheets are smelly and you really don't want to know what those brown-greenish stains are.
You wonder what kind of person would live in such a place.
Next to the bed is a wooden {nightstand}.";

                        case Intent.ThingBedNightstand:
                            if (currentState.BedState.DrawerIsLocked)
                                return @"You look at a wooden {nightstand}.
It has three drawers which are completely empty.
At least that's what you know about the first two, because the third {drawer} is locked.";
                            else
                                return @"You look at a wooden {nightstand}.
It has three drawers which are completely empty.
Except for the third one, which has some things in it.
""What things?"" you may ask, but you'll know it if you [open] the {drawer}.";

                        case Intent.ThingBedDrawer:
                            if (currentState.BedState.DrawerIsLocked)
                                return @"You see a locked drawer. I guess you want to know what's inside, right?
Seems like you have to find a key first.
Because obviously the key you found earlier doesn't fit here...";
                            else if (currentState.BedState.DrawerIsClosed)
                                return @"You see a closed drawer. If you want to know what's inside you should [open] it first.";
                            else
                                return @"Now that the {drawer} is open, you see that there is a lot of rubbish.
Some rubberbands, a bunch of pins and stuff like that.
But in between those things you see a " + Inventory.Battery + " and a" + Inventory.PieceOfPaperYellow + @".
You think that these two might come in handy.";
                    }
                    break;

                case Intent.ActionUse:
                    if (intent.Thing == Intent.ThingKey)
                    {
                        if (currentState.BedState.DrawerIsLocked)
                            return "The {drawer} is already unlocked, no need to use the key anymore.";
                        //if (currentState.Inventory.Contains(Inventory.UnknownKey))
                        {

                        }
                    }
                    break;
            }

            return null;
        }
    }
}
