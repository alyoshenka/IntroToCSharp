using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{
    class Program
    {

        static string[] badValues = { "bad", "test" };
        static string replacement = "*";
        static char command = '-';
        static void Welcome()
        {
            Console.WriteLine("Welcome to ChatBot\nPress e to exit");
        }
        static string TakeInput()
        {
            Console.WriteLine("Say something:");
            string s = Console.ReadLine();
            if (!CheckCommand(s))
            {
                s = Filter(s);
                Console.WriteLine("You said:\n" + s);
            }           
            return s;
        }
        static string Filter(string s)
        {
            foreach(string value in badValues)
            {
                int replacementCount = value.Length;
                // replace bad val with same number of characters
                s = s.Replace(value, String.Concat(Enumerable.Repeat(replacement, value.Length)));
            }
            return s;
        }

        // returns if string was a command
        static bool CheckCommand(string s)
        {
            if (s[0] != command) return false;

            // check for commands
            if(s == "-t")
            {
                Console.WriteLine("you want to test something");
            }
            return true;
        }
        static void Main(string[] args)
        {
            // welcome
            // take inout
            // check commands
            // check filter
            // print input/response
            Welcome();
            string input = "";
            while(input != "e")
            {
                input = TakeInput();
            }
        }
       
    }
}
