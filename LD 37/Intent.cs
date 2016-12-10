using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class Intent
    {
        public const string ActionWTF = "WTF";

        public const string _42 = "42";

        public const string ActionLookAtRoom = "LookAtRoom";
        public const string ActionGoto = "Goto";
        public const string ActionTake = "Take";
        public const string ActionUse = "Use";

        public const string ThingLight = "Light";
        public const string ThingKey = "Key";

        public string Action { get; private set; }
        public string Thing { get; private set; }
        public string Merged { get { return Action + Thing; } }

        public bool IsInvalidThing { get; private set; }

        public Intent(string action, string thing = "", bool isInvalidThing = false)
        {
            Action = action;
            Thing = thing;
            IsInvalidThing = isInvalidThing;
        }
    }
}
