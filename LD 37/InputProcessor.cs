using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    public class InputProcessor
    {
        //private class IntentMatcher
        //{
        //    private List<string> _matches = new List<string>();
        //    private string _intentKey;

        //    public IntentMatcher(string intentKey, params string[] matches)
        //    {
        //        _intentKey = intentKey;
        //        _matches.AddRange(matches);
        //    }

        //    public bool TryMatch(string input, out string intentKey)
        //    {
        //        intentKey = string.Empty;

        //        //foreach (var match in _matches)
        //        //{
        //        //    if (input == match)
        //        //    {
        //        //        intentKey = _intentKey;
        //        //        return true;
        //        //    }
        //        //}

        //        //if (input.StartsWith("go") || input.StartsWith("go"))

        //        return false;
        //    }
        //}

        public class Noun
        {
            public string NounKey { get; private set; }
            public List<string> Nouns { get; private set; }

            public Noun(string nounKey, params string[] nouns)
            {
                NounKey = nounKey;
                Nouns = new List<string>(nouns);
            }

            public bool TryMatch(string input)
            {
                foreach (var noun in Nouns)
                {
                    if (input.StartsWith(noun))
                    {
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
                    if (input.StartsWith(verb))
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
            //_dict.Add(new IntentMatcher(Intent._42, "what is the meaning of life", "the answer to life the universe and everything"));

            //_dict.Add(new IntentMatcher(Intent.LookAtRoom, "look", "look around", "look at room", "lookaround"));
            //_dict.Add(new IntentMatcher(Intent.Goto, "go to", "goto"));
            //_dict.Add(new IntentMatcher(Intent.GotoLight, "go to light", "goto light", "gotolight", "checkout light"));
            //_dict.Add(new IntentMatcher(Intent.Take, "take"));
            //_dict.Add(new IntentMatcher(Intent.TakeKey, "take key", "takekey"));
            //_dict.Add(new IntentMatcher(Intent.Use, "use"));
            //_dict.Add(new IntentMatcher(Intent.UseKey, "use key", "usekey"));

            _verbs.Add(new Verb(Intent.ActionLookAtRoom
                    , new string[] { "look", "look around", "lookaround", "look at room", "lookatroom" }
                ));

            _verbs.Add(new Verb(Intent.ActionGoto
                    , new string[] { "go to", "goto", "checkout", "check out" }
                    , Intent.ThingLight
                ));

            _verbs.Add(new Verb(Intent.ActionTake
                    , new string[] { "take", "pick up" }
                    , Intent.ThingKey
                ));

            _nouns.Add(new Noun(Intent.ThingLight, "light", "lightsource"));
            _nouns.Add(new Noun(Intent.ThingKey, "key"));
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
                return new Intent(Intent.ActionWTF);

            if (input.Length == 0)
                return new Intent(matchedVerb.VerbKey);

            Noun matchedNoun = null;
            foreach (var noun in _nouns)
            {
                if (noun.TryMatch(input))
                {
                    matchedNoun = noun;
                    break;
                }
            }
            if (matchedNoun == null || !matchedVerb.NounKeys.Contains(matchedNoun.NounKey))
                return new Intent(matchedVerb.VerbKey, input, true);

            //var intentKey = string.Empty;
            //foreach (var matcher in _dict)
            //{
            //    if (matcher.TryMatch(input, out intentKey))
            //        return new Intent(intentKey);
            //}

            return new Intent(matchedVerb.VerbKey, matchedNoun.NounKey);
        }
    }
}
