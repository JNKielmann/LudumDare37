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
        Exit,
        Window
    }
    public class TutorialState
    {
        public bool IsFree { get; set; } = false;
        public bool NextToLightSwitch { get; set; } = false;
        public bool LightOn { get; set; } = false;
    }
    public class PictureState
    {
        public bool PickedUpPicture { get; set; } = false;
    }
    public class State
    {
        public Location Location { get; set; } = Location.Tutorial;

        public TutorialState TutorialState { get; set; } = new TutorialState();
        public List<string> Inventory { get; } = new List<string>();
    }
}
