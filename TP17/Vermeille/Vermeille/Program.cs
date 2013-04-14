using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace Vermeille
{
    class Program
    {
        static void Main()
        {
            int b = 0;
            int e = 0;
            List<string> keywords = new List<string> {"a", "b", "c"};
            foreach (string keyword in keywords)
            {
                Console.WriteLine(QueueHashtable.Hash(keyword));
            }
            Stopwatch s = new Stopwatch();
            s.Start();
            Exo8.FindSmallerSequence(keywords, "toogy", ref b, ref e);
            s.Stop();

            Console.WriteLine(b + " - " + e);
            Console.WriteLine("Elapsed: " + s.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
