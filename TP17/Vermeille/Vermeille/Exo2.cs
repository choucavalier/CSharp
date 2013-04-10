using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo2
    {
        public static float Mediane(List<float> list)
        {
            Quicksort(list, 0, list.Count - 1);
            // ShellSort(list);
            foreach (float f in list)
            {
                Console.Write(f + " - ");
            }
            return list.Count%2 == 0 ? ((list[list.Count/2] + list[list.Count/2 + 1])/2) : list[list.Count/2 + 1];
        }

        /*private static void ShellSort(List<float> list)
        {
            int[] gaps = new [] {701, 301, 132, 57, 23, 10, 4, 1};
            foreach (int gap in gaps)
            {
                for (int i = gap; i < list.Count; i++)
                {
                    float temp = list[i];
                    int j = i;
                    while (j >= gap && list[j - gap] > temp)
                    {
                        list[j] = list[j - gap];
                    }
                    list[j] = temp;
                }
            }
        }*/

        private static void Quicksort(List<float> list, int beg, int end)
        {
            if (beg >= end) return;
            int piv = end, stor = beg;
            Swap(list, piv, end);
            for (int i = beg; i < end; i++)
                if (list[i] < list[piv])
                {
                    Swap(list, i, stor);
                    stor++;
                }
            Swap(list, stor, end);
            piv = stor;
            Quicksort(list, beg, piv - 1);
            Quicksort(list, piv + 1, end);
        }

        private static void Swap(List<float> list, int x, int y)
        {
            float c = list[x];
            list[x] = list[y];
            list[y] = c;
        }
    }
}
