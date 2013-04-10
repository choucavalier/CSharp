using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Vermeille
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < 5000; i++)
            {
                Data.Ht.Insert(r.Next(5000));
            }
            s.Stop();
            Data.Ht.Insert(6969);
            Console.WriteLine(Data.Ht.ToString());
            Console.WriteLine(Data.Ht.Search(6969));
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
