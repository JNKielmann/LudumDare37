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
                case Intent.ActionRead:
                    if (intent.Thing == Intent.ThingBedFlyer)
                        return _ReadFlyer(currentState);
                    break;

                case Intent.ActionSearch:
                    switch (intent.Thing)
                    {
                        case Intent.ThingBed:
                            return _LookAtBed();
                        case Intent.ThingBedDrawer:
                            return _LookAtDrawer(currentState);
                        case Intent.ThingBedNightstand:
                            return _LookAtNightStand(currentState);
                    }
                    break;

                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingBed:
                            return _LookAtBed();

                        case Intent.ThingBedNightstand:
                            return _LookAtNightStand(currentState);

                        case Intent.ThingBedDrawer:
                            return _LookAtDrawer(currentState);

                        case Intent.ThingBedFlyer:
                            return _ReadFlyer(currentState);
                    }
                    break;

                case Intent.ActionUnlock:
                    if (intent.Thing == Intent.ThingBedDrawer)
                        return _UnlockDrawer(intent, currentState);
                    break;

                case Intent.ActionUse:
                    if (intent.Thing == Intent.ThingKey)
                        return _UnlockDrawer(intent, currentState);
                    break;

                case Intent.ActionOpen:
                    if (intent.Thing == Intent.ThingBedDrawer)
                    {
                        if (!currentState.BedState.DrawerIsClosed)
                            return "You already opened the drawer.\nDoesn't really make sense to open it again, doesn't it?";
                        if (!currentState.BedState.DrawerIsLocked)
                        {
                            currentState.BedState.DrawerIsClosed = false;
                            currentState.Inventory.Add(Inventory.Battery);
                            currentState.Inventory.Add(Inventory.PieceOfPaperYellow);
                            return @"You opened the {drawer} and see..... mostly rubbish.
Some rubberbands, a bunch of pins and stuff like that.
But in between those things you see a " + Inventory.Battery + @"
and a " + Inventory.PieceOfPaperYellow + @".
You think that these two might come in handy so you put them in your [inventory].";
                        }
                        else
                            return "The drawer is still locked so you can't open it.";
                    }
                    break;

                case Intent.ActionTake:
                    if (!currentState.BedState.DrawerIsClosed)
                    {
                        switch (intent.Thing)
                        {
                            case Intent.ThingBattery:
                                if (currentState.Inventory.Contains(Inventory.Battery))
                                    return "You already took the " + Inventory.Battery + ". [Look at] your {inventory} if you don't believe me!";
                                currentState.Inventory.Add(Inventory.Battery);
                                return "You took the " + Inventory.Battery + ".";
                            case Intent.ThingPaper:
                                if (currentState.Inventory.Contains(Inventory.PieceOfPaperYellow))
                                    return "You already took the {paper}. You can find it in you {inventory}!";
                                currentState.Inventory.Add(Inventory.PieceOfPaperYellow);
                                return "You took the " + Inventory.PieceOfPaperYellow + ".";
                        }
                    }
                    if (intent.Thing == Intent.ThingBedFlyer)
                    {
                        if (currentState.Inventory.Contains(Inventory.Flyer))
                            return "You already picked up the {flyer}, if you want to read it [open] your {inventory}.";
                        currentState.Inventory.Add(Inventory.Flyer);
                        return "You picked up the {flyer}. [Open] your {inventory} to read its content.";
                    }
                    break;
            }

            return null;
        }

        private static string _UnlockDrawer(Intent intent, State currentState)
        {
            if (!currentState.BedState.DrawerIsLocked)
                return "The {drawer} is already unlocked, no need to use the key anymore.";
            if (currentState.Inventory.Contains(Inventory.UnknownKey))
            {
                currentState.Inventory.Remove(Inventory.UnknownKey);
                currentState.Inventory.Add(Inventory.NightstandKey);
                currentState.BedState.DrawerIsLocked = false;
                return @"It seems like the {key} you found in the {wardrobe} fits the {drawer} 
and now you succesfully unlocked it.";
            }
            return "You can't unlock the {drawer} if you don't have the correct {key}.";
        }

        private static string _LookAtBed()
        {
            return @"You are standing in front of an old {bed}.
The sheets are smelly and you really don't want to know what those brown-greenish stains are.
You wonder what kind of person would live in such a place.
Under the pillow you can see a {flyer} with some kind of advertisement.
Next to the bed is a wooden {nightstand}.";
        }

        private static string _LookAtNightStand(State currentState)
        {
            if (currentState.BedState.DrawerIsLocked)
                return @"You look at a wooden {nightstand}.
It has three drawers which are completely empty.
At least that's what you know about the first two, 
because the third {drawer} is locked.";
            else
                return @"You look at a wooden {nightstand}.
It has three drawers which are completely empty.
Except for the third one, which has some things in it.
""What things?"" you may ask, but you'll know it if you [open] the {drawer}.";
        }

        private static string _LookAtDrawer(State currentState)
        {
            if (currentState.BedState.DrawerIsLocked)
                return @"You see a locked drawer. I guess you want to know what's inside, right?
Seems like you have to find a key first.
Because obviously the key you found earlier doesn't fit here...";
            else if (currentState.BedState.DrawerIsClosed)
                return @"You see a closed drawer. 
If you want to know what's inside you should [open] it first.";
            else
            {
                currentState.Inventory.Add(Inventory.Battery);
                currentState.Inventory.Add(Inventory.PieceOfPaperYellow);
                return @"Now that the {drawer} is open, you see that there is a lot of rubbish.
Some rubberbands, a bunch of pins and stuff like that.
But in between those things you see a " + Inventory.Battery + @" 
and a " + Inventory.PieceOfPaperYellow + @".
You think that these two might come in handy so you put them in your [inventory].";
            }
        }

        private static string _ReadFlyer(State currentState)
        {
            if (currentState.Inventory.Contains(Inventory.Flyer))
                return "You already picked up the {flyer}, if you want to read it [open] your {inventory}.";
            return Inventory.Flyer;
        }
    }
}
