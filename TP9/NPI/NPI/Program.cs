using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPI
{
    class Program
    {
        static List<string> lexed;
        static List<string> allowed_ops = new List<string> { "+", "-", "*", "/", "%" };
        static void Lex(string s)
        {
            lexed = new List<string> { };
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;
                int x;
                if (int.TryParse(s[i].ToString(), out x))
                {
                    int n = x;
                    int j = i + 1;
                    while (j < s.Length && int.TryParse(s[j].ToString(), out x))
                    {
                        n = n * 10 + x;
                        j++;
                    }
                    lexed.Add(n.ToString());
                    i = j;
                }
                else
                {
                    if (allowed_ops.Contains(s[i].ToString()))
                    {
                        lexed.Add(s[i].ToString());
                    }
                    else
                    {
                        throw new Exception("Vous utilisez un ou plusieurs caracteres interdit(s). Rapellons que les caracteres autorises sont : / * - + % et des nombres entiers.");
                    }
                }
            }
        }

        static double Evaluate(List<string> l)
        {
            try
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (allowed_ops.Contains(l[i]))
                    {
                        if (l[i] == "+")
                            l[i - 2] = (double.Parse(l[i - 2]) + double.Parse(l[i - 1])).ToString();
                        else if (l[i] == "-")
                            l[i - 2] = (double.Parse(l[i - 2]) - double.Parse(l[i - 1])).ToString();
                        else if (l[i] == "*")
                            l[i - 2] = (double.Parse(l[i - 2]) * double.Parse(l[i - 1])).ToString();
                        else if (l[i] == "/")
                        {
                            if (int.Parse(l[i - 1]) == 0)
                                throw new Exception("Division par zero");
                            l[i - 2] = (double.Parse(l[i - 2]) / double.Parse(l[i - 1])).ToString();
                        }
                        else if (l[i] == "%")
                        {
                            if (int.Parse(l[i - 1]) == 0)
                                throw new Exception("Division par zero");
                            l[i - 2] = (double.Parse(l[i - 2]) % double.Parse(l[i - 1])).ToString();
                        }

                        l.RemoveAt(i - 1);
                        l.RemoveAt(i - 1);
                        i = 0;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            while (l.Count > 1)
            {
                if (l[2] == "+")
                    l[0] = (double.Parse(l[0]) + double.Parse(l[1])).ToString();
                else if (l[2] == "-")
                    l[0] = (double.Parse(l[0]) - double.Parse(l[1])).ToString();
                else if (l[2] == "*")
                    l[0] = (double.Parse(l[0]) * double.Parse(l[1])).ToString();
                else if (l[2] == "/")
                {
                    if (int.Parse(l[1]) == 0)
                        throw new Exception("Division par zero");
                    l[0] = (double.Parse(l[0]) / double.Parse(l[1])).ToString();
                }
                else if (l[2] == "%")
                {
                    if (int.Parse(l[1]) == 0)
                        throw new Exception("Division par zero");
                    l[0] = (double.Parse(l[0]) % double.Parse(l[1])).ToString();
                }

                l.RemoveAt(1);
                l.RemoveAt(1);
            }

            return double.Parse(l[0]);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Entrez votre formule en Notation Polonaise inverse");
                string s = Console.ReadLine();
                Lex(s);
                Console.WriteLine(Evaluate(lexed).ToString());
            }
        }
    }
}
