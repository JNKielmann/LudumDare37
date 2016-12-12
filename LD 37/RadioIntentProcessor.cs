using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class RadioIntentProcessor
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
                        case Intent.ThingRadio:
                            return "It is an old radio. Maybe it still works?";
                    }
                    break;
                case Intent.ActionInsert:
                    switch (intent.Thing)
                    {
                        case Intent.ThingBattery:
                            return HandleUseBattery(currentState);
                    }
                    break;
                case Intent.ActionUse:
                    switch (intent.Thing)
                    {
                        case Intent.ThingRadio:
                            if (currentState.RadioState.HasPower)
                            {
                                if (currentState.RadioState.Channel == 84)
                                {
                                    return "On channel 84 you still hear \"Attention: Red Red Red Attention: Red Red Red \" over and over again.";
                                }
                                else
                                {
                                    return "It works! But you only hear a static noise. You should try to switch the channel.";
                                }
                            }
                            else
                            {
                                return "You press the on button but nothing happens. You notice that the battery is missing.";
                            }
                        case Intent.ThingBattery:
                            return HandleUseBattery(currentState);

                    }
                    break;
                case Intent.ActionSwitch:
                    switch (intent.Thing)
                    {
                        case Intent.ThingChannel:
                            if(!currentState.RadioState.HasPower)
                            {
                                return "The radio has no power...";
                            }
                            if (string.IsNullOrWhiteSpace(intent.Parameter))
                            {
                                return "Which channel do you want to switch to? It seems like there are 100 channels.";
                            }
                            else
                            {
                                int channel;
                                if (int.TryParse(intent.Parameter, out channel))
                                {
                                    currentState.RadioState.Channel = channel;
                                    if (channel < 1 || channel > 100)
                                    {
                                        return "This channel does not seem to be valid. Try a channel between 1 and 100";
                                    }
                                    else if (channel == 84)
                                    {
                                        return "After you switch to channel 84 you here some kind of broadcast. It keeps repeating \"Attention: Red Red Red Attention: Red Red Red \" ... strange.";
                                    }
                                    else
                                    {
                                        return $"Full of hope you switch to channel {channel} .... But there is only static ....";
                                    }
                                }
                                else
                                {
                                    return "This channel does not seem to be valid. Try a channel between 1 and 100";
                                }

                            }
                    }
                    break;
            }
            return null;
        }

        private static string HandleUseBattery(State currentState)
        {
            if (currentState.Inventory.Contains(Inventory.Battery))
            {
                currentState.RadioState.HasPower = true;
                return "You put the battery into the radio";
            }
            else
            {
                return "You don't have a new battery";
            }
        }
    }
}
