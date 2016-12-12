using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public enum Location
    {
        Tutorial,
        Bed,
        Wardrobe,
        Radio,
        Picture,
        Door,
        Window,
        Trapdoor
    }
    public class TutorialState
    {
        public bool EyesAreClosed { get; set; } = true;
        public bool IsFree { get; set; } = false;
        public bool NextToLightSwitch { get; set; } = false;
        public bool LightOn { get; set; } = false;
    }
    public class PictureState
    {
        public bool PickedUpPicture { get; set; } = false;
    }
    public class RadioState
    {
        public bool HasPower { get; set; } = false;
        public int Channel { get; set; } = 1;
    }
    public class DoorState
    {
        public const int Password = 4391; // Blue = 4, Red = 3, Yellow = 9, Green = 1
        public const int MaxPasswordAttemptsUntilbruteforceDetection = 15;

        public int PasswordAttempts { get; set; } = 0;
        public bool DoorIsUnlocked { get; set; } = false;
        public bool FinalDecicsion_ReadPostIt { get; set; } = false;
        public bool FinalDecicsion_PressCtrlC { get; set; } = false;
    }
    public class BedState
    {
        public bool DrawerIsLocked { get; set; } = true;
        public bool DrawerIsClosed { get; set; } = true;
    }
    public class WardrobeState
    {
        public bool IsOpen { get; set; } = false;
    }
    public class EasterEggState
    {
        public int InsultCount { get; set; } = 0;
    }
    public class State
    {
        public Location Location { get; set; } = Location.Tutorial;

        public TutorialState TutorialState { get; set; } = new TutorialState();
        public PictureState PictureState { get; set; } = new PictureState();
        public RadioState RadioState { get; set; } = new RadioState();
        public DoorState DoorState { get; set; } = new DoorState();
        public BedState BedState { get; set; } = new BedState();
        public WardrobeState WardrobeState { get; set; } = new WardrobeState();
        public EasterEggState EasterEggState { get; set; } = new EasterEggState();
        public List<string> Inventory { get; } = new List<string>();
    }
}
