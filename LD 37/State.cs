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
    public class State
    {
        public Location Location { get; set; } = Location.Tutorial;         
    }
}
