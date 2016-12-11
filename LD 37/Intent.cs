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

        public const string ActionEnter = "Enter";
        public const string ActionOpen = "Open";
        public const string ActionLookAtRoom = "LookAtRoom";
        public const string ActionLookAt = "LookAt";
        public const string ActionGoto = "Goto";
        public const string ActionTake = "Take";
        public const string ActionUse = "Use";
        public const string ActionSwitch = "Switch";
        public const string ActionRead = "Read";
        public const string ActionSearch = "Search";
        public const string ActionInventory = "Inventory";
        public const string ActionPress = "Press";

        public const string ThingInventory = "Inventory";
        public const string ThingLight = "Light";
        public const string ThingKey = "Key";
        public const string ThingLightSwitch = "LightSwitch";

        public const string ThingBed = "Bed";
        public const string ThingBedNightstand = "Nightstand";
        public const string ThingBedDrawer = "Drawer";
        public const string ThingWardrobe = "Wardrobe";
        public const string ThingRadio = "Radio";
        public const string ThingPicture = "Picture";
        public const string ThingDoor = "Door";
        public const string ThingDoorKeyPad = "KeyPad";
        public const string ThingDoorPostIt = "PostItNote";

        public const string ThingFloor = "Floor";
        public const string ThingCrackInFloor = "CrackInFloor";
        public const string ThingPaper = "Paper";

        public const string ThingChannel = "Channel";
        public const string ThingBattery = "Battery";

        public const string ThingClothes = "Clothes";





        public string Action { get; private set; }
        public string Thing { get; private set; }
        public string Merged { get { return Action + Thing; } }

        public bool IsInvalidThing { get; private set; }
        public string Parameter { get; private set; }

        public Intent(string action, string thing = "", bool isInvalidThing = false, string parameter = "")
        {
            Action = action;
            Thing = thing;
            IsInvalidThing = isInvalidThing;
            Parameter = parameter;
        }
    }
}
