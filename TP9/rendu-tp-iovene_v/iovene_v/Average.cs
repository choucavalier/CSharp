using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP9
{
    class Program
    {
        static int Moyenne(List<int> li)
        {
            int r = 0;

            for (int i = 0; i < li.Count; i++)
            {
                r += li[i] >= 0 ? li[i] : 0;
            }

            return r / li.Count;
        }

        static void Error()
        {
            Console.WriteLine("Je veux un entier naturel, putain c'est pas complique ?!");
            Console.WriteLine("- - - - - - - - - - - - - - - -");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                List<int> li = new List<int> { };

                Console.WriteLine("Combien de nombres desirez-vous tres cher ?");
                int h;
                if (!int.TryParse(Console.ReadLine(), out h))
                {
                    Error();
                    continue;
                }
                else
                {
                    if (h == 0)
                        Console.WriteLine("Moyenne : 0");
                    else
                    {
                        for (int i = 1; i < h+1; i++)
                        {
                            Console.WriteLine("Nombre " + i + " :");
                            li.Add(int.Parse(Console.ReadLine()));
                        }
                        Console.Write("Moyenne : " + Moyenne(li));
                    }
                }
                Console.WriteLine();
                Console.ReadLine();
            }
            
        }
    }
}
