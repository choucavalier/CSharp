using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Sapin(n);
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
        }

        static List<ConsoleColor> colorsList = new List<ConsoleColor> { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Blue };

        static byte[] randomNumber = new byte[1];
        static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        static void Sapin(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = (i < 2) ? ConsoleColor.Yellow : ConsoleColor.Green;

                for (int j = 0; j < (n-i); j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < (2*i-1); j++)
                {
                    rngCsp.GetBytes(randomNumber);
                    if (j == 0 && i == 1)
                        Console.Write("$");
                    else
                    {
                        if (randomNumber[0] % 4 == 3)
                        {
                            rngCsp.GetBytes(randomNumber);
                            Console.ForegroundColor = colorsList[randomNumber[0] % 6];
                            Console.Write("o");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        else
                        {
                            Console.Write("*");
                        }
                    }
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < n / 2; i++)
            {
                string s = "";

                for (int j = 0; j < ((2 * n - 1) / 2); j++)
                {
                    s += " ";
                }

                s += "#";

                Console.WriteLine(s);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
