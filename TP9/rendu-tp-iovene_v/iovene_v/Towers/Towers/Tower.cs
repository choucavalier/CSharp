using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Towers
{
    class Tower
    {
        static void PrintTower(string t, string b, string m, string s, int e)
        {
            Console.WriteLine(t);

            for (int i = 0; i < e; i++)
            {
                Console.WriteLine(s);
                Console.WriteLine(m);
            }

            Console.WriteLine(s);
            Console.WriteLine(b);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Entrez le haut de la tour :");
                string t = Console.ReadLine();

                Console.WriteLine("Entrez un étage décoré :");
                string m = Console.ReadLine();

                Console.WriteLine("Entrez un étage vide :");
                string s = Console.ReadLine();

                Console.WriteLine("Entrez le bas de la tour :");
                string b = Console.ReadLine();

                Console.WriteLine("Entrez le nombre d'étage que vous souhaitez afficher :");
                int e;
                if (!int.TryParse(Console.ReadLine(), out e))
                {
                    Console.WriteLine(e + "n'est pas un entier naturel correcte.");
                    continue;
                }
                PrintTower(t, b, m, s, e);

                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}