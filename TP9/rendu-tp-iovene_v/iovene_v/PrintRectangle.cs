using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP9
{
    class Program
    {
        static void PrintNStrings(int n, string c)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(c);
            }
            Console.Write("\n");
        }

        static void Error()
        {
            Console.WriteLine("Des entiers naturels bon sang !");
        }

        static void PrintRectangle(int n, int m)
        {
            for (int i = 1; i < m + 1; i++)
            {
                if (i == 1 || i == m)
                    PrintNStrings(n, "*");
                else
                {
                    Console.Write("*");
                    for (int k = 0; k < n - 2; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                    Console.Write("\n");
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Entrez la largeur :");
                int l;
                if (!int.TryParse(Console.ReadLine(), out l))
                {
                    Error();
                    continue;
                }

                Console.WriteLine("Entrez la hauteur :");
                int h;
                if (!int.TryParse(Console.ReadLine(), out h))
                {
                    Error();
                    continue;
                }

                PrintRectangle(l, h);

                Console.ReadLine();
            }
        }
    }
}
