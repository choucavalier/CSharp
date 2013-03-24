using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathieuAUnChat
{
    class Program
    {
        public static void Main()
        {
            Random r = new Random();
            MyMagicArray<int> woo = new MyMagicArray<int>();
            for (int i = 0; i < 100; i++)
                woo.InsertOrdered(r.Next(1, 50) * 2);
            woo.Print(x => true);
            woo.Select(x => x%2 == 0).Print(x => true);
            Console.WriteLine("Sort >");
            Console.ReadLine();
            woo.Quicksort(0, 9);
            woo.Print(x => true);
            Console.ReadLine();
        }
    }
}
