using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo7
    {
        public static void LinearSort(List<byte> list)
        {
            int min = 0;
            int max = 0;
            foreach (byte t in list)
            {
                if (t < min)
                    min = t;
                if (t > max)
                    max = t;
            }
            int[] b = new int[max - min + 1];

            foreach (byte t in list)
                b[t]++;

            int last = 0;
            for (int i = 0; i < b.Length; i++)
                for (int j = 0; j < b[i]; j++)
                    list[last++] = (byte) i;
        }
    }
}
