using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(WordCount(s));
            Console.ReadLine();
        }

        static int WordCount(string s)
        {
            return s.Split(new[] {' '}).Length;
        }
    }
}
