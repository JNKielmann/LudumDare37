using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    class DoorIntentProcessor
    {
        static public string Process(Intent intent, State currentState)
        {
            switch (intent.Action)
            {
                case Intent.ActionLookAt:
                    switch (intent.Thing)
                    {
                        case Intent.ThingDoor:
                            return Strings.Get(Strings.Keys.DoorIntent_LookAt_Door);
                        case Intent.ThingDoorKeyPad:
                            return Strings.Get(Strings.Keys.DoorIntent_LookAt_DoorKeyPad);
                        default:
                            return null;
                    }
            }

            return null;
        }
    }
}
