using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo3
    {
        public static void BrainFuck(string str)
        {
            int i = 0, d;
            List<byte> oct = new List<byte> { 0 };
            for (int k = 0; k < str.Length - 1; k++)
            {
                if (str[k] == '>')
                    if (++i >= oct.Count)
                        oct.Add(0);
                if (str[k] == '<' && i > 0)
                    i--;
                if (str[k] == '+' && oct[i] < 255)
                    oct[i]++;
                if (str[k] == '-' && oct[i] > 0)
                    oct[i]--;
                if (str[k] == '.')
                    Console.Write((char)oct[i]);
                if (str[k] == ',')
                    oct[i] = (byte) Console.ReadKey().KeyChar;
                if (str[k] == ']')
                {
                    d = 1;
                    while (--k >= 0 && d != 0)
                    {
                        if (str[k] == ']')
                            d++;
                        if (str[k] == '[')
                            d--;
                    }
                    k++;

                }
                if (str[k] == '[' && oct[i] == 0)
                {
                    d = 1;
                    while (++k < str.Length && d != 0)
                    {
                        if (str[k] == ']')
                            d--;
                        if (str[k] == '[')
                            d++;
                    }
                    k--;
                }
            }
        }
    }
}