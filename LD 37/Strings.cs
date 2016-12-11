using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public static class Strings
    {
        public enum Keys
        {
            Tutorial_Introduction
                , Tutorial_LookAtRom
                , Tutorial_Goto_Light_NextTo
                , Tutorial_Goto_Light_IsFree
                , Tutorial_Goto_Light_IsEnchained
                , Tutorial_Take_Key
                , Tutorial_Take_Key_AlreadyInInventory
                , Tutorial_Use_Key_IsFree
                , Tutorial_Use_Key_IsEnchained_HasKey
                , Tutorial_Use_Key_IsEnchained_HasNoKey
                , Tutorial_Use_LightSwitch_LightOn
                , Tutorial_Use_LightSwitch_LightOff

                , DoorIntent_LookAt_Door
                , DoorIntent_LookAt_DoorKeyPad

                , Unknown_Intent
        }

        private static Dictionary<Keys, string> _strings;

        public static string Get(Keys key)
        {
            if (_strings.ContainsKey(key))
                return _strings[key];
            return string.Empty;
        }

        static Strings()
        {
            _strings = new Dictionary<Keys, string>();
            _strings.Add(
                    Keys.Tutorial_Introduction, 
@"Hello fellow stranger!
I have bad news for you.
You are in a dark room. Maybe you could try to [look around]?"
                );
            _strings.Add(
                    Keys.Tutorial_LookAtRom,
                    "You see a small {light} in the distance. Maybe you should [go to] that {light}."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_NextTo,
                    "You are already here. The small amout of light seems to be coming from a {light switch}. Maby you should [use] it."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_IsFree,
                    "As you slowly make your way through the darkness you realiste that the small light is a {light switch}."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_IsEnchained,
                    "You notice that you can not move because you are enchained. But you feel a {key} next to you. Maybe you should [take] it."
                );
            _strings.Add(
                    Keys.Tutorial_Take_Key,
                    "You took the {key} and put it in your {inventory}. Maybe you can [use] it to free yourself."
                );
            _strings.Add(
                    Keys.Tutorial_Take_Key_AlreadyInInventory,
                    "Take the {key}..what? Ohhh you mean the {key} that is already in your {inventory}...silly!"
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsFree,
                    "You are already free. What are you waiting for? [Check out] that small {light}."
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsEnchained_HasKey,
                   "You freed yourself and can move around freely. It's still dark though and you only see a small {light}"
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsEnchained_HasNoKey,
                   "You don't have the {key} to free yourself."
                );
            _strings.Add(
                    Keys.Tutorial_Use_LightSwitch_LightOn,
                   "It's not a good idea to turn the light back off again."
                );
            _strings.Add(
                    Keys.Tutorial_Use_LightSwitch_LightOff,
                   "The room is filled with light. The first thing you notice is the big {wardrobe} infront of you. Next to that you see a {bed} with a little {nightstand}. On the ground you see a {picture}, but you can not see whats on it from the distance. There is also a {radio}, maybe it still works? As you look behind you, you see a big steel {door}. What do you want to [check out] first?"
                );


            _strings.Add(
                    Keys.DoorIntent_LookAt_Door,
                    @"You are standing in front of a massive steel {door} and ask yourself ""Why the hell are you here?"".
You can see that you need to enter a four digit password into a {keypad} to open the door. The digits seem to be colored. What does that mean?
Maybe you can find some hints in this room?"
                );
            _strings.Add(
                    Keys.DoorIntent_LookAt_DoorKeyPad,
                    @"You look at a {keypad} that accepts four digits. The first digit is blue, the second red, the third yello and the last one is green. 
Quite interesting isn't it?"
                );


            _strings.Add(
                    Keys.Unknown_Intent,
@"I have no idea what you mean by that..."
                );
        }
    }
}
