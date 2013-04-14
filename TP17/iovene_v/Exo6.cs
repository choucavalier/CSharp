using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vermeille
{
    class Exo6
    {
        private List<Interval> _intervals = new List<Interval>();

        public void AddInterval(float begin, float end)
        {
            Interval toAdd = new Interval(begin, end);
            List<int> toMerge = new List<int>();
            bool toMergeEmpty = true;

            if (_intervals.Count == 0)
            {
                _intervals.Add(toAdd);
                return;
            }

            for (int i = 0; i < _intervals.Count; i++)
            {
                // Interval situe a droite du ieme interval, aucun float en commun
                if (toAdd.BeginFloat > _intervals[i].EndFloat)
                {
                    if ((i + 1 < _intervals.Count && _intervals[i + 1].BeginFloat > toAdd.EndFloat) || _intervals.Count == 1)
                    {
                        _intervals.Insert(i + 1, toAdd);
                        return;
                    }

                    continue;
                }

                if (toAdd.EndFloat < _intervals[i].BeginFloat)
                {
                    if (toMergeEmpty || i == 0)
                    {
                        _intervals.Insert(i, toAdd);
                        return;
                    }
                    break;
                }

                // Interval entierement inclu dans le ieme interval
                if (toAdd.EndFloat < _intervals[i].EndFloat && toAdd.BeginFloat > _intervals[i].BeginFloat && toMergeEmpty)
                    return;

                toMerge.Add(i);
                if (toMergeEmpty)
                    toMergeEmpty = false;
            }

            if (!toMergeEmpty)
            {
                if (_intervals[toMerge[0]].BeginFloat > toAdd.BeginFloat)
                    _intervals[toMerge[0]].BeginFloat = toAdd.BeginFloat;

                _intervals[toMerge[0]].EndFloat = _intervals[toMerge[toMerge.Count - 1]].EndFloat > toAdd.EndFloat ? _intervals[toMerge[toMerge.Count - 1]].EndFloat : toAdd.EndFloat;

                if (toMerge.Count > 1)
                    for (int i = toMerge[1]; i <= toMerge[toMerge.Count - 1]; i++)
                    {
                        _intervals.RemoveAt(i);
                        i++;
                    }
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (var interval in _intervals)
                s += "[" + interval.BeginFloat + " - " + interval.EndFloat + "] ";
            s += "\n";
            return s;
        }

        public void DeleteInterval(float begin, float end)
        {
            Interval toDelete = new Interval(begin, end);
            List<int> toMerge = new List<int>();
            bool toMergeEmpty = true;

            if (_intervals.Count == 0)
                return;

            for (int i = 0; i < _intervals.Count; i++)
            {
                if (toDelete.BeginFloat > _intervals[i].EndFloat)
                    continue;

                if (toDelete.EndFloat < _intervals[i].BeginFloat && (toMergeEmpty || i == 0))
                    break;

                if (toDelete.EndFloat < _intervals[i].EndFloat && toDelete.BeginFloat > _intervals[i].BeginFloat)
                {
                    _intervals.Insert(i + 1, new Interval(toDelete.EndFloat + float.Epsilon, _intervals[i].EndFloat));
                    _intervals[i].EndFloat = toDelete.BeginFloat - float.Epsilon;
                    return;
                }

                toMerge.Add(i);
                if (toMergeEmpty)
                    toMergeEmpty = false;
            }

            if (!toMergeEmpty)
            {
                _intervals[toMerge[0]].EndFloat = toDelete.BeginFloat;
                _intervals[toMerge[toMerge.Count - 1]].BeginFloat = toDelete.EndFloat;

                if (toMerge.Count > 1)
                    for (int i = toMerge[1]; i <= toMerge[toMerge.Count - 1]; i++)
                    {
                        _intervals.RemoveAt(i);
                        i++;
                    }
            }
        }

        public bool Mem(float x)
        {
            if (_intervals.Count == 0)
                return false;
            return Mem(x, 0, _intervals.Count - 1);
        }

        public bool Mem(float x, int imin, int imax)
        {
            if (imax < imin)
                return false;
            int imid = (imax + imin) / 2;

            if (_intervals[imid] > x)
                return Mem(x, imin, imid - 1);
            if (_intervals[imid] < x)
                return Mem(x, imid + 1, imax);
            return true;
        }
    }

    public class Interval
    {
        public float BeginFloat;
        public float EndFloat;

        public Interval(float beginFloat, float endFloat)
        {
            BeginFloat = beginFloat;
            EndFloat = endFloat;
        }

        public static bool operator <(Interval i, float x)
        {
            return i.EndFloat < x;
        }

        public static bool operator >(Interval i, float x)
        {
            return i.BeginFloat > x;
        }

        public bool Contains(float x)
        {
            return EndFloat <= x && BeginFloat >= x;
        }
    }
}
