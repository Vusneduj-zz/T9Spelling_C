using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace T9SpellingLib.App
{
    class T9SpellingApp
    {
        static void Main(string[] args)
        {
            T9Spelling spelling = new T9Spelling();

            string input_str = "4\nhi\nyes\nfoo  bar\nhello world";

            Console.WriteLine("Input:");
            Console.WriteLine(input_str);

            string  result_string   = spelling.MainProcess(input_str);

            Console.WriteLine("\nOutput:");
            Console.WriteLine(result_string);
        }
    }
}
