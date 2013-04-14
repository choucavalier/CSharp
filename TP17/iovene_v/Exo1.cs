using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo1
    {
        public static int MinMax(int a, int b, int c)
        {
            return a > b ? b > c ? b : c > a ? a : c : a > c ? a : c > b ? b : c;
        }
    }
}
