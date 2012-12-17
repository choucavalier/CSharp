using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    class Program
    {
        static string RotN(int n, string str)
        {
            string s = ""; // On cree une string vide, a laquelle on va rajouter les caracteres modifies uns a uns. Cette string sera en fait le resultat de la rotation
            foreach (char c in str) // On parourt la chaine a crypter
            {
                if (c >= 'A' && c <= 'Z') // On gere les majuscules
                    s += Convert.ToChar((c - 65 + n) % 26 + 65); // On fait attention a pas depasser les majuscules du code ASCII
                else
                {
                    if (c >= 'a' && c <= 'z') // Puis les minuscule
                    {
                        s += Convert.ToChar((c - 97 + n) % 26 + 97); // Idem pour les majuscules
                    }
                    else
                    {
                        s += c; // Si le caractere n'est pas dans l'alphabet, on ne le modifie pas
                    }
                }
            }

            return s; // Et on renvoit la chaine qu'on a creee bout a bout depuis le debut du foreach
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bonjour, bienvenue dans mon logiciel de cryptage.");
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Cet algorithme de cryptage gere tous les indices de rotation que vous voulez, tant que ce sont des entiers relatifs");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Chaine a crypter : \n");
            Console.Write("> "); // On demande a l'utilisateur de rentrer la string qu'il veut crypter
            string str = Console.ReadLine();
            Console.WriteLine("Indice de rotation : \n");
            Console.Write("> "); // Puis on lui demande quel indice de rotation il souhaite
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
                n = 0;
            Console.WriteLine();
            Console.WriteLine("RESULTAT -->");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Et enfin on lui renvoit le resultat de sa rotation
            Console.WriteLine((str == "") ? "Chaine vide..." : RotN(n, str));
        }
    }
}
