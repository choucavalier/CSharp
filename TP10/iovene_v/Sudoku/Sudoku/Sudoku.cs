using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TPCSharp4
{
	class Sudoku
	{
        public static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.newbiecontest.org/epreuves/prog/progsudoku.php");

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("SMFCookie89", "a%3A4%3A%7Bi%3A0%3Bs%3A5%3A%2263879%22%3Bi%3A1%3Bs%3A40%3A%22e6c4e0d61f5dadc7653b214f594eb66188628b64%22%3Bi%3A2%3Bi%3A1553258272%3Bi%3A3%3Bi%3A0%3B%7D", "/", "www.newbiecontest.org"));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string str = sr.ReadToEnd();

            string[] nbrs = str.Split(new[] { "<td class=\"chiffe\">", "<td class=\"chiffe1\">" }, StringSplitOptions.None);

            string str1 = "";

            for (int i = 1; i < nbrs.Length; i++)
                str1 += nbrs[i][0];

            str = "";

            for (int i = 0; i <= 60; i += 27)
                for (int j = i; j <= i + 6; j += 3)
                    for (int k = j; k <= j + 18; k += 9)
                        str = str + str1[k] + str1[k + 1] + str1[k + 2];

            int[,] sudo = new int[9,9];

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    sudo[j, i] = int.Parse(str[9*j+i].ToString());
            Solve(ref sudo);

            str = "";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    str = str + sudo[i, j].ToString();
                if (i != 8)
                    str = str + "-";
            }
            
            PrintTab(sudo);
            Console.WriteLine(str);
            
            Process p = new Process();
            p.StartInfo.FileName = "http://www.newbiecontest.org/epreuves/prog/verifprsudoku.php?solution=" + str;
            p.Start();


            Console.ReadLine();
        }

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
                for (int j = 0; j < 9; j++)
                    if (tab[i, j] == 0)
                        return false;
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