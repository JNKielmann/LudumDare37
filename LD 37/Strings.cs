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

                , UnknownIntent
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
                    Keys.UnknownIntent,
@"I have no idea what you mean by that..."
                );
        }
    }
}
