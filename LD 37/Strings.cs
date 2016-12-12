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
                , Room_Description
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
                    @"Darkness surrounds you...
Are you still alive?
Are you dead?
.².².²
No! You can't be, your head aches.
If you're dead you wouldn't feel pain, right?
You hear noises.².².²
Small water dripplets?
Where are you?
Who did this to you?
What do they want from you?
So many qestions are going through your mind...
Now that you figured out that you are not dead you notice your eyes are closed.
You think the first thing you should do is [open] your {eyes}."
                );
            _strings.Add(
                    Keys.Tutorial_LookAtRom,
                    @"As you scan the dark environment your {eyes} catch a small {light} in the distance.
Because you realize that this might be your only clue, you want to [go to] 
the {light} to find out where it's coming from."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_NextTo,
                    @"You are already next to the {light switch}.
I would say it is a much better idea to [use] the {switch}."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_IsFree,
                    @"As you slowly make your way through the darkness you realise
that the small {light} is coming from a {light switch}.
You think it would be a good idea to [use] it."
                );
            _strings.Add(
                    Keys.Tutorial_Goto_Light_IsEnchained,
                    @"You notice that you can not move because you are enchained. 
But you feel a {key} next to you.
You also feel a sudden urge to [take] it."
                );
            _strings.Add(
                    Keys.Tutorial_Take_Key,
                    @"You took the {key} and put it in your {inventory}. 
Maybe now would be a good idea to [use] it to free yourself."
                );
            _strings.Add(
                    Keys.Tutorial_Take_Key_AlreadyInInventory,
                    "Take the {key}..what? Ohhh you mean the {key} that is already in your {inventory}...silly!"
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsFree,
                    @"You are already free. What are you waiting for?
[Go to] that small {light}."
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsEnchained_HasKey,
                   @"You freed yourself and can move around freely. 
It's still dark though and you can still only see the small {light}."
                );
            _strings.Add(
                    Keys.Tutorial_Use_Key_IsEnchained_HasNoKey,
                   "You don't have a {key} to free yourself."
                );
            _strings.Add(
                    Keys.Tutorial_Use_LightSwitch_LightOn,
                   @"As you move your hand towards the {light switch} to turn it off,
you realise that this doesn't make much sense."
                );
            _strings.Add(
                    Keys.Tutorial_Use_LightSwitch_LightOff,
                   @"Full of hope that the {switch} is working, you raise your hand to flip it.
.³.³.³
""Bright², dark², bright², dark², ..."" you think as the light flickers until it stays on.
""Perfect!"".
After a few seconds your eyes adjusted themselves to the brightness.
Now that the room is filled with light, the silhouettes are revealed 
and you see the objects in the room."
                );

            _strings.Add(Keys.Room_Description,
                @"The first thing you notice is a big steel {door}.
The walls of your ""prison"" are made of very old bricks.
They look like they could collapse at any moment.
One of the walls has a [window] on it, but the [window] is barricaded.
Right in front of you you notice there is a {wardrobe} 
that casts a big shadow on the floor.
As your eyes follow the shadow you see that it ends on a {trapddor}.
Next to that you see a {bed}.
Why is there furniture in here? Just like as if somebody would
live in this shack.
On the ground you see a {picture}, but from the distance you can 
not clearly see what it shows. 
There is also a {radio} standing on a table, maybe it still works?
But the last thing you see really gives you goosebumps.³.³.³
In one corner of the room is a surveillance camera.
""Who...is...watching...me?""

You wonder where you [go to] next?"
                );


            _strings.Add(
                    Keys.DoorIntent_LookAt_Door,
                    @"You are standing in front of a massive steel {door} and
ask yourself ""Why the hell are you here?"".
You can see that you need to enter a four digit password into a {keypad} to open the door. 
The digits seem to be colored. What does that mean?
If you [look at] the keypad 
Maybe you can find some hints in this room?"
                );
            _strings.Add(
                    Keys.DoorIntent_LookAt_DoorKeyPad,
                    @"You look at a {keypad} that accepts four digits. 
The first digit is blue, the second red, the third yellow and
the last one is green. 
Quite interesting isn't it?"
                );


            _strings.Add(
                    Keys.Unknown_Intent,
@"I have no idea what you mean by that..."
                );
        }
    }
}
