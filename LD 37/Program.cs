#define TypeAnimation
#if DEBUG
#undef TypeAnimation
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LD_37
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ludum Dare 37 - The Room";

            var state = new State();
            var inputProcessor = new InputProcessor();
            var intentProcessor = new IntentProcessor();

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

        private static Random randomTyper = new Random();
        static void WriteInColor(string text, bool newLine = true)
        {
            int index = 0;
            foreach (char character in text) {
                switch (character)
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
                    case '²':
#if TypeAnimation
                        Thread.Sleep(300);
#endif
                        break;
                    case '³':
#if TypeAnimation
                        Thread.Sleep(600);
#endif
                        break;
                    default:
                        Console.Write(character);
#if TypeAnimation
                        if (character == '\n' && index > 1 && (text[index - 1] == '\r' ? _CharIsEndOfSentence(text[index-2]) : _CharIsEndOfSentence(text[index - 1])))
                            Thread.Sleep(randomTyper.Next(250, 500)); //Thread.Sleep(250);
                        else
                            Thread.Sleep(randomTyper.Next(30, 50)); //Thread.Sleep(30);
#endif
                        break;
                }
                ++index;
            }
            if (newLine)
                Console.WriteLine();
        }

        private static bool _CharIsEndOfSentence(char c)
        {
            switch (c)
            {
                case '.':
                case '!':
                case '?':
                case ':':
                    return true;
                default:
                    return false;
            }
        }
    }
}
