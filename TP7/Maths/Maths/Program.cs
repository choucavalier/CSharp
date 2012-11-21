using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maths
{
    class Program
    {

        const float pi = 3.1415926f;

        /* Si b est nul, alors on renvoit la partie entiere de a
         * Sinon, 
         */
        static float approx(float a, int b)
        {
            return b == 0 ? (float)(int)a : approx(a * 10, b - 1) / 10;
        }

        static float my_sqrt(float a)
        {
            if (a == 0) return 0;
            float b = 1;
            for (int i = 1; i < a; i++)
            {
                b = (b + a / b) / 2;
            }
            return b;
        }

        static float my_pow(float a, int b)
        {
            return (b == 0) ? 1 : (a * my_pow(a, b-1));
        }

        static bool is_prim(int x)
        {
            if (x % 2 == 0)
                return false;
            for (int i = 3; i < x; i += 2)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }

        static bool is_sexy(int a, int b)
        {
            if (a > 1000 || b > 1000 || !is_prim(a) || !is_prim(b)) return false;
            return (a - b == 6 || b - a == 6) ? true : false;
        }

        static int facto(int a)
        {
            return (a == 0) ? 1 : (a * facto(a - 1));
        }

        static float deg_to_rad(float d)
        {
            return (d * (pi/180));
        }

        static float rad_to_deg(float r)
        {
            return (r * (180/pi));
        }

        static float my_cos(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2*pi : 0);
            float b = 0;
            for (int i = 0; i < 6; i++)
            {
                b += (my_pow(-1, i) * my_pow(a, 2 * i)) / facto(2 * i);
            }
            return approx(b,4);
        }

        static float my_sin(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2 * pi : 0);
            float b = 0;
            for (int i = 0; i < 6; i++)
            {
                b = b + (my_pow(-1, i) * my_pow(a, 2 * i + 1)) / facto(2 * i + 1);
            }
            return approx(b,4);
        }

        static float my_tan(float a)
        {
            return my_sin(a) / my_cos(a);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(my_sin(pi/4));
        }
    }
}
