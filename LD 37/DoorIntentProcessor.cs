using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    class DoorIntentProcessor
    {
        public static string Process(Intent intent, State currentState)
        {
            if (currentState.DoorState.FinalDecicsion_PressCtrlC == true)
                return "It's no use..go ahead and press 'CTRL-C', you won!";

            if (currentState.DoorState.FinalDecicsion_ReadPostIt)
            {
                if ((intent.Action == Intent.ActionRead || intent.Action == Intent.ActionLookAt)
                        && intent.Thing == Intent.ThingDoorPostIt)
                {
                    currentState.DoorState.FinalDecicsion_PressCtrlC = true;
                    return @"On the note you read the following lines:
""The answer to escape the room was always in front of you!""
""Just press 'CTRL-C' and you are free...""

Well this is awkward...";
                }
                return "Please...all I want you to do now is [read] the {post-it}.";
            }

            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    return _ProcessLookAt(intent, currentState);
                case Intent.ActionUse:
                    return _ProcessUse(intent, currentState);
                case Intent.ActionEnter:
                    if (intent.Thing == Intent.ThingDoor)
                        return _ProcessUseDoor(intent, currentState);
                    if (intent.Thing == Intent.ThingDoorKeyPad)
                        return _ProcessUseKeypad(intent, currentState);
                    break;
                case Intent.ActionOpen:
                    if (intent.Thing == Intent.ThingDoor)
                        return _ProcessUseDoor(intent, currentState);
                    break;
            }

            return null;
        }

        private static string _ProcessLookAt(Intent intent, State currentState)
        {
            switch (intent.Thing)
            {
                case Intent.ThingDoor:
                    return Strings.Get(Strings.Keys.DoorIntent_LookAt_Door);
                case Intent.ThingDoorKeyPad:
                    if (currentState.DoorState.DoorIsUnlocked)
                        return "After pressing the right buttons on the keypad you can read the word \"correct\" on the display";
                    return Strings.Get(Strings.Keys.DoorIntent_LookAt_DoorKeyPad);
                default:
                    return null;
            }
        }

        private static string _ProcessUse(Intent intent, State currentState)
        {
            switch (intent.Thing)
            {
                case Intent.ThingDoor:
                    return _ProcessUseDoor(intent, currentState);

                case Intent.ThingDoorKeyPad:
                    return _ProcessUseKeypad(intent, currentState);
                default:
                    return null;
            }
        }

        private static string _ProcessUseKeypad(Intent intent, State currentState)
        {
            string pass;
            if (string.IsNullOrWhiteSpace(intent.Parameter))
            {
                Console.Write("You must type in the four digit password: ");
                pass = Console.ReadLine();
            }
            else
                pass = intent.Parameter;
            if (pass.Length < 4 || pass.Length > 4)
                return "I said a <FOUR DIGIT> password...";
            int digit;
            if (!int.TryParse(pass, out digit))
                return "One question: Do you know what <NUMBERS> are?";
            if (digit != DoorState.Password)
                return "You pressed the small buttons on the keypad. But unfortunately you only hear a buzzing sound which probably means that the password was wrong.";
            currentState.DoorState.DoorIsUnlocked = true;
            return "As you pressed the small buttons on the keypad you can hear a faint 'click' sound.\nDid it work? Did you really enter the correct password?\nThere's only one way to find out!";
        }

        private static string _ProcessUseDoor(Intent intent, State currentState)
        {
            if (currentState.DoorState.DoorIsUnlocked)
            {
                currentState.DoorState.FinalDecicsion_ReadPostIt = true;
                return @"Because the smart you was able to enter the correct password, the door is now unlocked.
But after opening it you only see a wall.
The same old brick wall as the rest of this lame room.
""This door is freaking useless!"" you think.
But wait...do you see what I see? Yes - there is a little {post-it note} on the wall.
Maybe you should [read] it?";
            }
            return "\"You huff and you puff and you blow the house .. oh I mean door .. away\", but it doesn't move.\nMaybe you are not as strong as ou think you are?";
        }
    }
}
