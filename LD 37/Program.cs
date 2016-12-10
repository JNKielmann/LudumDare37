using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD_37
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ludum Dare 37";

            var state = new State();
            var inputProcessor = new InputProcessor();
            var intentProcessor = new IntentProcessor();
#if DEBUG
            state.TutorialState.LightOn = true;
            state.Location = Location.Door;
#endif
            Console.WriteLine(Strings.Get(Strings.Keys.Tutorial_Introduction));
            while(true)
            {
                var input = Console.ReadLine();
                var intent = inputProcessor.Process(input);
                var answer = intentProcessor.Process(intent, state);
                Console.WriteLine(answer);
            }
        }
    }
}
