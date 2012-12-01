using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allowedOps = new List<string> { "+", "-", "/", "*" };
            List<float> nb = new List<float> { };
            List<string> ops = new List<string> { };

            #region table-genesis
            
            foreach (string a in args)
            {
                float x;
                if (float.TryParse(a, out x))
                    nb.Add(float.Parse(a));

                else
                {
                    if (a.Length > 2 && a[0] == '+' && a[1] == '+' && float.TryParse(a.Substring(2), out x))
                        nb.Add(x + 1);
                    else
                    {
                        if (a.Length > 2 && a[0] == '-' && a[1] == '-' && float.TryParse(a.Substring(2), out x))
                            nb.Add(x - 1);
                        else
                        {
                            if (a.Length == 1 && allowedOps.Contains(a))
                                ops.Add(a);
                            else
                            {
                                Console.WriteLine("Argument invalide");
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }

            #endregion

            #region calculage-ou-calculation-hehe

            // Si il n'y a pas d'operateur, on renvoit une erreur
            if (ops.Intersect(allowedOps).Count() == 0)
                Console.WriteLine("Pas d'operateur");

            else
            {
                // On applique les multiplications d'abord
                while (ops.Contains("*"))
                {
                    int i = ops.IndexOf("*");
                    nb[i] = nb[i] * nb[i + 1];
                    nb.RemoveAt(i + 1);
                    ops.RemoveAt(i);
                }

                // Puis les divisions, en gerant bien evidemment les divisions par zero
                while (ops.Contains("/"))
                {
                    int i = ops.IndexOf("/");

                    if (nb[i + 1] == 0)
                    {
                        Console.WriteLine("...Petite erreur...");
                        Console.WriteLine("Division par zero interdite, considerons que ca fait zero...");
                        Console.WriteLine("...Le calcul continue");
                        nb[i] = 0;
                    }
                    else
                        nb[i] = nb[i] / (nb[i + 1]);

                    nb.RemoveAt(i + 1);
                    ops.RemoveAt(i);
                }

                // Puis les additions
                while (ops.Contains("+"))
                {
                    int i = ops.IndexOf("+");
                    nb[i] = nb[i] + (nb[i + 1]);
                    nb.RemoveAt(i + 1);
                    ops.RemoveAt(i);
                }

                // Puis les soustractions
                while (ops.Contains("-"))
                {
                    int i = ops.IndexOf("-");
                    nb[i] = nb[i] - (nb[i + 1]);
                    nb.RemoveAt(i + 1);
                    ops.RemoveAt(i);
                }

                // Et on ecrit le resultat de tout ca, tranquillement
                Console.WriteLine(nb[0].ToString());
            }

            #endregion
        }
    }
}
