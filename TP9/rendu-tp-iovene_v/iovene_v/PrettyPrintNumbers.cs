using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP9
{
    class PrettyPrintNumbers
    {
        static void PrettyPrintNumbers(int a, int b, int p)
        {
            for (int i = a; i < b; i += p)
            {
                Console.Write(i + ", ");
            }
            Console.Write("et " + b);
        }

        static void Error()
        {
            Console.WriteLine("Veuillez entrer un nombre correcte.");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Entrez le premier nombre :");
                int a;
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Error();
                    continue;
                }

                Console.WriteLine("Entrez le dernier nombre :");
                int b;
                if (!int.TryParse(Console.ReadLine(), out b))
                {
                    Error();
                    continue;
                }

                Console.WriteLine("Entrez le pas :");
                int p;
                if (!int.TryParse(Console.ReadLine(), out p))
                {
                    Error();
                    continue;
                }

                Console.WriteLine("#################################");
                Console.WriteLine("Resultat :");
                PrettyPrintNumbers(a, b, p);

                Console.ReadLine();
            }
        }
    }
}
