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
            var state = new State();
            var inputProcessor = new InputProcessor();
            var intentProcessor = new IntentProcessor();
            Console.WriteLine("You are in a dark room. Type \"look around.\"");
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
