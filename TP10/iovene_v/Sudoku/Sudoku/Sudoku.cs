using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TPCSharp4
{
	class Sudoku
	{
		static Random rnd = new Random ();

        public static void InitTab(int[,] tab)
        {
            tab.Initialize();
        }

        static void PrintTab(int[,] tab)
        {
            Console.WriteLine("+-----------------------+");

            for (int m = 0; m < 9; m += 3)
            {
                for (int k = m; k < m + 3; k++)
                {
                    Console.Write("| ");
                    for (int i = 0; i < 9; i += 3)
                    {
                        Console.Write(tab[k, i] == 0 ? "  " : tab[k, i] + " ");
                        Console.Write(tab[k, i + 1] == 0 ? "  " : tab[k, i + 1] + " ");
                        Console.Write(tab[k, i + 2] == 0 ? "  " : tab[k, i + 2] + " ");
                        Console.Write("| ");
                    }
                    Console.Write("\n");
                }
                if (m < 6)
                    Console.Write("|-------+-------+-------|\n");
            }

            Console.Write("+-----------------------+\n");
        }

        static void RandomlyFillTab(int[,] tab, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int rx = rnd.Next(0, 9),
                    ry = rnd.Next(0, 9),
                    rn = rnd.Next(1, 10);

                if (tab[rx, ry] == 0)
                {
                    bool b = true;
                    for (int j = 0; j < 9; j++)
                    {
                        if (tab[rx, j] == rn)
                        {
                            b = false;
                            break;
                        }
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        if (tab[j, ry] == rn)
                        {
                            b = false;
                            break;
                        }
                    }

                    for (int rx0 = (rx / 3) * 3, rxm = rx0 + 3; rx0 < rxm; rx0++)
                    {
                        for (int ry0 = (ry / 3) * 3, rym = ry0 + 3; ry0 < rym; ry0++)
                        {
                            if (tab[rx0, ry0] == rn)
                            {
                                b = false;
                                break;
                            }
                        }
                    }

                    if (b)
                    {
                        tab[rx, ry] = rn;
                    }
                    else
                        i--;
                }

                else
                {
                    i--;
                }
            }
        }
        /*
        #region BONUS-REAL-RANDOM

        static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static void SwapGridNumbers(ref int[,] tab)
        {
            int a = rnd.Next(1, 10), b = a;

            while (b == a)
            {
                b = rnd.Next(1, 10);
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (tab[i, j] == a)
                        tab[i, j] = b;
                    else if (tab[i, j] == b)
                        tab[i, j] = a;
                }
            }
        }

        static void MixGridLines(ref int[,] tab)
        {
            for (int i = 0; i <= 6; i += 3)
            {
                int rn1 = rnd.Next(i, i + 3), rn2 = rn1;

                while (rn2 == rn1)
                {
                    rn2 = rnd.Next(i, i + 3);
                }

                for (int x = 0; x < 9; x++)
                {
                    Swap(ref tab[x, rn1], ref tab[x, rn2]);
                }
            }
        }

        static void RandomlyFillTab2(ref int[,] tab)
        {
            for (int i = 0; i < 2000; i++)
            {
                SwapGridNumbers(ref tab);
                MixGridLines(ref tab);
            }
        }

        #endregion 
        */
        static void GetLinePossibleNumbers(ref List<int> numList, int x, int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                if (tab[x, i] != 0)
                    numList.Remove(tab[x, i]);
            }
        }

        static void GetColumnPossibleNumbers(ref List<int> numList, int y, int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                if (tab[i, y] != 0)
                    numList.Remove(tab[i, y]);
            }
        }

        static void GetRegionPossibleNumbers(ref List<int> numList, int x, int y, int[,] tab)
        {
            for (int x0 = (x / 3) * 3, xm = x0 + 3; x0 < xm; x0++)
            {
                for (int y0 = (y / 3) * 3, ym = y0 + 3; y0 < ym; y0++)
                {
                    if (tab[x0, y0] != 0)
                        numList.Remove(tab[x0, y0]);
                }
            }
        }

        static void GetMinList(ref List<int> minList, ref int xIndex, ref int yIndex, int[,] tab)
        {
            int xn = 0, yn = 0;
            List<int> numList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numListLocal;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (tab[i, j] == 0)
                    {
                        numListLocal = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        GetColumnPossibleNumbers(ref numListLocal, j, tab);
                        GetLinePossibleNumbers(ref numListLocal, i, tab);
                        GetRegionPossibleNumbers(ref numListLocal, i, j, tab);

                        if (numListLocal.Count < numList.Count)
                        {
                            xn = i;
                            yn = j;
                            numList = numListLocal;
                            if (numListLocal.Count == 1)
                                break;
                        }
                    }
                }
            }
            xIndex = xn;
            yIndex = yn;
            minList = numList;
        }

        static bool IsFinished(int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (tab[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        static int counter = 0;

        static bool Solve(ref int[,] tab)
        {
            counter++;
            if (IsFinished(tab))
                return true;

            int[,] saveTab = new int[9, 9];

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    saveTab[i, j] = tab[i, j];

            List<int> minList = new List<int> { };
            int xIndex = 0, yIndex = 0;
            GetMinList(ref minList, ref xIndex, ref yIndex, saveTab);

            if (minList.Count == 0)
                return false;

            while (minList.Count == 1)
            {
                saveTab[xIndex, yIndex] = minList[0];
                GetMinList(ref minList, ref xIndex, ref yIndex, saveTab);
            }

            if (IsFinished(saveTab))
            {
                tab = saveTab;
                return true;
            }

            foreach(int i in minList)
            {
                saveTab[xIndex, yIndex] = i;

                if (Solve(ref saveTab))
                {
                    tab = saveTab;
                    return true;
                }
            }
            
            return false;
        }

	}
}