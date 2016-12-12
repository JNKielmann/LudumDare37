using System;

namespace LD_37
{
    public class EasterEggIntentProcessor
    {
        public static string Process(Intent intent, State currentState)
        {
            if (intent.Parameter.StartsWith("your mama") || intent.Parameter.StartsWith("yo mama")
                || intent.Parameter.StartsWith("your mum") || intent.Parameter.StartsWith("yo mum"))
                return _HandleInsult(intent, currentState);

            switch (intent.Parameter)
            {
                #region 42 - Reference
                case "what is the meaning of life":
                case "the answer to life the universe and everything":
                case "what is the answer to life the universe and everything":
                    return "42";
                case "42":
                case "what is 42":
                case "what means 42":
                    return "The answer to life, the universe and everything.";
                #endregion

                #region Insults
                case "fuck you":
                case "you suck":
                case "you are gay":
                    return _HandleInsult(intent, currentState);
                #endregion
            }

            return null;
        }


        private static string _HandleInsult(Intent intent, State currentState)
        {
            string answer = $"Okay that's enough...you know what? <\"Well {intent.Parameter} too!\">";
            switch (currentState.EasterEggState.InsultCount)
            {
                case 0:
                    answer = "What?...that was rude!";
                    break;
                case 1:
                    answer = "Yep...";
                    break;
                case 2:
                    answer = "Why are you saying things like that?";
                    break;
                case 3:
                    answer = "Are you done yet?";
                    break;
                case 4:
                    answer = "Okay now you are just trying to annoy me...";
                    break;
            }
            ++currentState.EasterEggState.InsultCount;
            return answer;
        }
    }
}