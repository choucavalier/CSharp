using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEB
{
    class Program
    {
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        public static bool SquareEven(ref int nb)
        {
            if (nb * nb % 2 == 0)
            {
                nb *= nb;
                return true;
            }
            else
                return false;
        }

        public static string TimeAfterTime(ref int days, ref int hours, ref int mins, ref int sec)
        {
            if (sec > 42661337)
                return "ERROR : invalid amount";
            if (sec >= 60)
            {
                mins += (int)(sec / 60);
                sec %= 60;
            }
            
            if (mins >= 60)
            {
                hours += (int)(mins / 60);
                mins %= 60;
            }

            if (hours >= 24)
            {
                days += (int)(hours / 24);
                hours %= 24;
            }

            List<string> e = new List<string> { };

            if (sec == 42)
                e.Add("sec");
            if (mins == 42)
                e.Add("mins");
            if (days == 42)
                e.Add("mins");

            int ec = e.Count;

            if (ec == 0)
                return "SUCCESS";
            else if (ec == 1)
                return "ERROR : [#42#] " + e[0];
            else
                return "Segmentation fault";
        }

        public static int CountMeMaybe(ref string str, string sample)
        {
            int count = 0;
            string samp = sample;
            for (int i = 0; i < Math.Min(str.Length, samp.Length); i++)
			{
                if (str[i] == samp[i])
                {
                    str = str.Remove(i, 1);
                    samp = samp.Remove(i, 1);
                    count++;
                    i--;
                }
			}

            return count;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
