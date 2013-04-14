using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo4
    {
        public static int PostFixEval(string str)
        {
            Stack<int> s = new Stack<int>();
            foreach (char c in str)
                if (c >= '0' && c <= '9')
                    s.Push(c - 48);
                else
                {
                    int x = s.Pop(), y = s.Pop();
                    s.Push(c == '+' ? x + y : c == '-' ? x - y : c == '*' ? x * y : c == '/' ? x / y : c == '%' ? x % y : 0);
                }
            return s.Pop();
        }
    }
}
