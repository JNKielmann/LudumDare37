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
            state.Location = Location.Radio;
            state.DoorState.FinalDecicsion_ReadPostIt = true;
#endif
            WriteInColor(Strings.Get(Strings.Keys.Tutorial_Introduction));
            while(true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                Console.WriteLine();
                var intent = inputProcessor.Process(input);
                var answer = intentProcessor.Process(intent, state);
                WriteInColor(answer);
                
            }
        }

        static void WriteInColor(string text)
        {
            foreach (char character in text) {
                switch(character)
                {
                    case '[':
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case '{':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case '<':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case ']':
                    case '}':
                    case '>':
                        Console.ResetColor();
                        break;
                    default:
                        Console.Write(character);
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
