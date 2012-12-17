using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP9
{
    class Maths
    {
        static int Multiplication(int a, int b)
        {
            int r = a;
            for (int i = 1; i < b; i++)
            {
                r += a;
            }
            return r;
        }

        static int Division(int a, int b)
        {
            int r = 0;
            for (int i = a; i > 0; i -= b)
            {
                r -= -1;
            }
            return r;
        }

        static int Factorielle(int n)
        {
            int r = 1;
            for (int i = n; i > 0; i--)
            {
                r *= i;
            }
            return r;
        }

        static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // BONUS

        static int FibonacciIter(int n)
        {
            int x = 1, y = 1, z;

            if (n == 0)
                return 0;

            for (int i = 3; i <= n; i++)
            {
                z = x + y;
                x = y;
                y = z;
            }

            return y;
        }
    }
}
