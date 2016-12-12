using System;

namespace LD_37
{
    internal class TrapdoorIntentProcessor
    {
        public static string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    if (intent.Thing == Intent.ThingTrapdoor)
                        return @"You look down towards the floor.
Your eyes lay upon an iron {trapdoor} which has a lock on it.
Now you want to know where it leads to." + (currentState.Inventory.Contains(Inventory.UnknownKey) 
    ? @"
Maybe the small {key} you got from the {wardrobe} can [unlock] it?" 
    : @"
But how can you open it without a fitting {key}?");
                    break;
                case Intent.ActionOpen:
                    if (intent.Thing == Intent.ThingTrapdoor)
                        return @"Because of the fact that the {trapdoor} is still locked
you won't even try to [open] it right now.";
                    break;

                case Intent.ActionUnlock:
                    if (intent.Thing == Intent.ThingTrapdoor)
                        return _TryUnlock(intent, currentState);
                    break;

                case Intent.ActionUse:
                    if (intent.Thing == Intent.ThingKey)
                        return _TryUnlock(intent, currentState);
                    break;
            }
            return null;
        }

        private static string _TryUnlock(Intent intent, State currentState)
        {
            if (currentState.Inventory.Contains(Inventory.UnknownKey))
                return @"Full of hope you try to [unlock] the {trapdoor} with
the small {key} you got from the {wardrobe}.
Unfortunately it doesn't fit.";
            else if (currentState.Inventory.Contains(Inventory.NightstandKey))
                return @"You look at the {key} from the {wardrobe} which fits
into the {drawer} and wish it would fit into this lock too.";
            return @"You currently don't have a {key} that fits inside the lock.";
        }
    }
}