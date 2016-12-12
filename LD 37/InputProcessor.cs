using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class InputProcessor
    {
        public class Noun
        {
            public string NounKey { get; private set; }
            public List<string> Nouns { get; private set; }

            public Noun(string nounKey, params string[] nouns)
            {
                NounKey = nounKey;
                Nouns = new List<string>(nouns);
            }

            public bool TryMatch(string input, out string actuallyMatchedNoun)
            {
                actuallyMatchedNoun = string.Empty;
                foreach (var noun in Nouns.OrderByDescending(n => n.Length))
                {
                    if ((input + " ").StartsWith(noun + " ") || (input + " ").StartsWith("the " + noun + " "))
                    {
                        actuallyMatchedNoun = noun;
                        return true;
                    }
                }
                return false;
            }
        }

        public class Verb
        {
            public string VerbKey { get; private set; }
            public List<string> Verbs { get; private set; }
            public List<string> NounKeys { get; private set; }

            public Verb(string verbKey, string[] verbs, params string[] nouns)
            {
                VerbKey = verbKey;
                Verbs = new List<string>(verbs);
                NounKeys = new List<string>(nouns);
            }

            public bool TryMatch(string input, out string actuallyMatchedVerb)
            {
                actuallyMatchedVerb = string.Empty;
                foreach (var verb in Verbs.OrderByDescending(v => v.Length))
                {
                    if ((input + " ").StartsWith(verb + " "))
                    {
                        actuallyMatchedVerb = verb;
                        return true;
                    }
                }
                return false;
            }
        }

        private static List<Verb> _verbs = new List<Verb>();
        private static List<Noun> _nouns = new List<Noun>();

        static InputProcessor()
        {
            _verbs.Add(new Verb(Intent.ActionInventory
                , new string[] { "inventory", "look at inventory", "open inventory" }
            ));
            _verbs.Add(new Verb(Intent.ActionLookAt
                    , new string[] { "look at" }
                    , Intent.ThingPicture
                    , Intent.ThingRadio
                    , Intent.ThingPicture
                    , Intent.ThingFloor
                    , Intent.ThingCrackInFloor
                    , Intent.ThingDoor
                    , Intent.ThingDoorKeyPad
                    , Intent.ThingBed
                    , Intent.ThingBedNightstand
                    , Intent.ThingBedDrawer
                    , Intent.ThingBedFlyer
                    , Intent.ThingWardrobe
                    , Intent.ThingWindow
                    , Intent.ThingTrapdoor
                ));
            _verbs.Add(new Verb(Intent.ActionLookAtRoom
                    , new string[] { "look", "look around", "lookaround", "look at room", "lookatroom" }
                ));
            _verbs.Add(new Verb(Intent.ActionGoto
                    , new string[] { "go", "go to", "goto" }
                    , Intent.ThingLight
                    , Intent.ThingBed
                    , Intent.ThingWardrobe
                    , Intent.ThingRadio
                    , Intent.ThingPicture
                    , Intent.ThingDoor
                    , Intent.ThingWindow
                    , Intent.ThingTrapdoor
                ));

            _verbs.Add(new Verb(Intent.ActionTake
                    , new string[] { "take", "pick up" }
                    , Intent.ThingKey
                    , Intent.ThingPicture
                    , Intent.ThingPaper
                    , Intent.ThingBedFlyer
                    , Intent.ThingBattery
                ));
            _verbs.Add(new Verb(Intent.ActionUse
                    , new string[] { "use" }
                    , Intent.ThingEyes
                    , Intent.ThingKey
                    , Intent.ThingRadio
                    , Intent.ThingBattery
                    , Intent.ThingKey
                    , Intent.ThingLightSwitch
                    , Intent.ThingDoor
                    , Intent.ThingDoorKeyPad
                ));
            _verbs.Add(new Verb(Intent.ActionSwitch
                    , new string[] { "switch", "set", "switch to", "change", "change to" }
                    , Intent.ThingChannel
                ));
            _verbs.Add(new Verb(Intent.ActionEnter
                    , new string[] { "enter" }
                    , Intent.ThingDoor
                    , Intent.ThingDoorKeyPad
                ));
            _verbs.Add(new Verb(Intent.ActionOpen
                    , new string[] { "open" }
                    , Intent.ThingEyes
                    , Intent.ThingDoor
                    , Intent.ThingBedDrawer
                    , Intent.ThingWardrobe
                    , Intent.ThingWindow
                    , Intent.ThingTrapdoor
                ));
            _verbs.Add(new Verb(Intent.ActionRead
                    , new string[] { "read" }
                    , Intent.ThingDoorPostIt
                    , Intent.ThingBedFlyer
                ));
            _verbs.Add(new Verb(Intent.ActionSearch
                    , new string[] { "search", "search in", "examine" }
                    , Intent.ThingWardrobe, Intent.ThingClothes
                    , Intent.ThingBed
                    , Intent.ThingBedNightstand
                    , Intent.ThingBedDrawer
                ));
            _verbs.Add(new Verb(Intent.ActionUnlock
                    , new string[] { "unlock" }
                    , Intent.ThingBedDrawer
                    , Intent.ThingDoor
                    , Intent.ThingDoorKeyPad
                    , Intent.ThingTrapdoor
                ));
            _verbs.Add(new Verb(Intent.ActionPress
                , new string[] { "press", "push", "flip" }
                , Intent.ThingLightSwitch
            ));
            _verbs.Add(new Verb(Intent.ActionInsert
                , new string[] { "insert", "put", "put in" }
                , Intent.ThingBattery
            ));

            _nouns.Add(new Noun(Intent.ThingEyes, "eyes", "your eyes", "my eyes"));
            _nouns.Add(new Noun(Intent.ThingLight, "light", "lightsource", "small light"));
            _nouns.Add(new Noun(Intent.ThingKey, "key"));
            _nouns.Add(new Noun(Intent.ThingBed, "bed"));
            _nouns.Add(new Noun(Intent.ThingBedNightstand, "nightstand", "night stand", "night table", "bedside table"));
            _nouns.Add(new Noun(Intent.ThingBedDrawer, "drawer", "third drawer"));
            _nouns.Add(new Noun(Intent.ThingBedFlyer, "flyer"));
            _nouns.Add(new Noun(Intent.ThingWardrobe, "wardrobe"));
            _nouns.Add(new Noun(Intent.ThingRadio, "radio"));
            _nouns.Add(new Noun(Intent.ThingPicture, "picture"));
            _nouns.Add(new Noun(Intent.ThingDoor, "door", "steel door", "big door", "big steel door", "exit"));
            _nouns.Add(new Noun(Intent.ThingDoorKeyPad, "keypad", "key pad"));
            _nouns.Add(new Noun(Intent.ThingDoorPostIt, "post-it note", "post-it", "note", "post it", "post it note"));
            _nouns.Add(new Noun(Intent.ThingLightSwitch, "lightswitch", "light switch", "switch"));
            _nouns.Add(new Noun(Intent.ThingFloor, "floor"));
            _nouns.Add(new Noun(Intent.ThingCrackInFloor, "crack in floor", "crack"));
            _nouns.Add(new Noun(Intent.ThingPaper, "paper", "piece of paper", "small piece of paper"));
            _nouns.Add(new Noun(Intent.ThingChannel, "channel", "frequency", "station"));
            _nouns.Add(new Noun(Intent.ThingBattery, "battery"));
            _nouns.Add(new Noun(Intent.ThingClothes, "clothes"));
            _nouns.Add(new Noun(Intent.ThingWindow, "window", "barricaded window"));
            _nouns.Add(new Noun(Intent.ThingTrapdoor, "trapdoor"));
        }



        public Intent Process(string input)
        {
            input = input.Trim()
                .Replace(",", "")
                .Replace(".", "")
                .Replace("?", "")
                .Replace("!", "")
                .Replace("\"", "")
                .Replace("'", "")
                .Replace("[", "")
                .Replace("]", "")
                .ToLower();

            Verb matchedVerb = null;
            foreach (var verb in _verbs)
            {
                string actuallyMatchedVerb;
                if (verb.TryMatch(input, out actuallyMatchedVerb))
                {
                    matchedVerb = verb;
                    input = input.Replace(actuallyMatchedVerb, "").Trim();
                    break;
                }
            }
            if (matchedVerb == null)
                return new Intent(Intent.ActionWTF, string.Empty, true, input);

            if (input.Length == 0)
                return new Intent(matchedVerb.VerbKey, string.Empty, true);

            var matchedNouns = new Dictionary<string, Noun>();
            string actuallyMatchedNoun = string.Empty;
            foreach (var noun in _nouns)
            {
                if (noun.TryMatch(input, out actuallyMatchedNoun))
                {
                    matchedNouns.Add(actuallyMatchedNoun, noun);
                }
            }
            if (matchedNouns.Count == 0)
                return new Intent(matchedVerb.VerbKey, input, true);
            var matchedNounPair = matchedNouns.OrderByDescending(pair => pair.Key.Length).FirstOrDefault();
            var matchedNoun = matchedNounPair.Value;
            if (matchedNoun == null || !matchedVerb.NounKeys.Contains(matchedNoun.NounKey))
                return new Intent(matchedVerb.VerbKey, input, true);


            input = input.Replace(matchedNounPair.Key, "").Trim();

            return new Intent(matchedVerb.VerbKey, matchedNoun.NounKey, false, input);
        }
    }
}
