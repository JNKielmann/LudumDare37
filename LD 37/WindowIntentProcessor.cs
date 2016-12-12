using System;

namespace LD_37
{
    internal class WindowIntentProcessor
    {
        public static string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    if (intent.Thing == Intent.ThingWindow)
                        return @"You look at the {window}.
The glass is broken but you can't climb through because it 
is barricaded with massive wooden planks.
You can only peek through some gaps in the wood.
But you don't really like what you see...
It's very dark and there is fog everywhere but yet
you see something move in the distance.
""What is that?"" you ask yourself.";
                    break;

                case Intent.ActionOpen:
                    if (intent.Thing == Intent.ThingWindow)
                        return @"You try to break the wooden barricades but they won't budge.";
                    break;
            }
            return null;
        }
    }
}