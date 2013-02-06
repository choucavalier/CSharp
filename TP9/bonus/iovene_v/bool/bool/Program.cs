using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @bool
{
    class Program
    {
        static List<char> allowedChars = new List<char> { '0', '1', '&', '|' };

        static bool isOk(ref List<char> s)
        {
            if (s.Count == 0)
                return false;
            for (int i = 0; i < s.Count ; i++)
            {
                if (s[i] == ' ')
                {
                    s.RemoveAt(i);
                    continue;
                }

                if (!allowedChars.Contains(s[i]))
                    throw new Exception("Caractere non-autorise : " + s[i]);
            }

            return true;
        }

        static int Eval(List<char> e)
        {
            while (e.Contains('&'))
            {
                int i = e.IndexOf('&');
                if (e[i - 1] != e[i + 1])
                    e[i - 1] = '0';
                e.RemoveAt(i); e.RemoveAt(i);
            }

            while (e.Contains('|'))
            {
                int i = e.IndexOf('|');
                if (e[i - 1] != e[i + 1])
                    e[i - 1] = '1';
                e.RemoveAt(i); e.RemoveAt(i);
            }

            return int.Parse(e[0].ToString());
        }

        static void Main(string[] args)
        {
            List<char> s;
            
            while(true)
            {
                Console.WriteLine("Entrez votre expression booleenne, que des 1, des 0, des & et des |.");
                s = Console.ReadLine().ToList();

                try
                {
                    if (!isOk(ref s))
                        continue;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Console.WriteLine("Resultat : " + Eval(s));

            Console.ReadLine();
        }
    }
}
