using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Vermeille
{
    internal class Exo8
    {
        public static void FindSmallerSequence(List<string> keywords, string filename, ref int start, ref int end)
        {
            int keywordsCount = 0;
            Sequence solution = new Sequence(0, int.MaxValue);
            List<int> kwi = new List<int>();
            QueueHashtable q = new QueueHashtable(keywords);

            using (FileStream fs = File.OpenRead(filename))
            {
                while (fs.Position < fs.Length)
                {
                    char c = (char) fs.ReadByte();
                    string currentWord = "";
                    while (c != ' ')
                    {
                        currentWord += c;
                        c = (char) fs.ReadByte();
                    }
                    int i = q.IndexOf(currentWord) - currentWord.Length + 1;
                    if (q.Kw[i].Key != currentWord)
                        continue;
                    if (!q.Kw[i].Value.Any())
                        keywordsCount++;
                    q.Kw[i].Value.Enqueue((int) fs.Position - 1);
                    kwi.Add(i);

                    if (keywordsCount == keywords.Count)
                    {
                        Sequence newSolution = new Sequence(0, 0);
                        while (keywordsCount == keywords.Count)
                        {
                            int index = kwi[0];
                            kwi.RemoveAt(0);
                            newSolution.Start = q.Kw[index].Value.Dequeue();
                            if (!q.Kw[index].Value.Any())
                                keywordsCount--;
                        }
                        newSolution.End = q.Kw[kwi[kwi.Count - 1]].Value.Peek();
                        if (newSolution.CompareTo(solution) < 0)
                        {
                            solution = newSolution;
                            Console.WriteLine(solution.Start + " - " + solution.End);
                            Console.WriteLine("##############");
                        }
                    }
                }
            }

            start = solution.Start;
            end = solution.End;
        }

        public class Sequence : IComparable
        {
            public int Start;
            public int End;

            public Sequence(int s, int e)
            {
                Start = s;
                End = e;
            }

            public int CompareTo(object o)
            {
                Sequence s = o as Sequence;
                if (s == null)
                    throw new Exception("Bad type");
                int x = End - Start, y = s.End - s.Start;
                if (x < y)
                    return -1;
                if (x > y)
                    return 1;
                return 0;
            }
        }
    }

    internal class QueueHashtable
    {
        public KeyValuePair<string, Queue<int>>[] Kw;

        public QueueHashtable(List<string> keywords)
        {
            Kw = new KeyValuePair<string, Queue<int>>[keywords.Count > 997 ? keywords.Count : 997];
            foreach (string keyword in keywords)
                Kw[IndexOf(keyword)] = new KeyValuePair<string, Queue<int>>(keyword, new Queue<int>());
        }

        public static int Hash(string s)
        {
            int r = 0;
            for (int i = 0; i < s.Length; i++)
            {
                r += (i+1)*s[i];
            }
            return r;
        }

        public int IndexOf(string s)
        {
            return Hash(s)%Kw.Length;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Kw.Length; i++)
            {
                if (Kw[i].Value != null)
                {
                    s += i + ": ";
                    foreach (int j in Kw[i].Value)
                    {
                        s +=j + " -> ";
                    }
                    s += '\n';
                }
            }
            return s;
        }
    }
}
