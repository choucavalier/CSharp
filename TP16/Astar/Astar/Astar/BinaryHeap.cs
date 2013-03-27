using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar
{
    class BinaryHeap<T>
    {
        private readonly List<T> _list = new List<T>();
        private readonly Func<T, T, bool> _comp; // Comparison operator.
        private readonly Func<T, T, bool> _equal; // Equality operator.

        public List<T> List { get { return _list; } } // Only a read access to the list.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comp">The comparison operator on which the binary heap is based (example for int : (x, y) => x < y)</param>
        /// <param name="equal">The predicate which define the equality between two elemente of type T (example for int : (x, y) => x == y)</param>
        public BinaryHeap(Func<T, T, bool> comp, Func<T, T, bool> equal)
        {
            _comp = comp;
            _equal = equal;
        }

        /// <summary>
        /// Insert an element in the tree, keeping the heap property
        /// </summary>
        /// <param name="elt">The element to insert</param>
        public void Add(T elt)
        {
            _list.Add(elt);
            int i = _list.Count - 1;
            while (i > 0 && !_comp(_list[(i - 1) / 2], _list[i]))
            {
                T temp = _list[i];
                _list[i] = _list[(i - 1) / 2];
                _list[(i - 1) / 2] = temp;
                i = (i - 1) / 2;
            }
        }

        /// <summary>
        /// Delete an element of the tree, keeping the heap property
        /// </summary>
        /// <param name="elt">The element to delete</param>
        public void Remove(T elt)
        {
            int i = _list.FindIndex((x) => _equal(x, elt));
            int length = _list.Count - 1;
            _list[i] = _list[length];
            _list.RemoveAt(length);
            int lowest = i;
            while (2 * i + 1 < length)
            {
                if (!_comp(_list[lowest], _list[2 * i + 1]))
                    lowest = 2 * i + 1;
                if (2 * i + 2 < length)
                    if (2 * i + 2 < length && !_comp(_list[lowest], _list[2 * i + 2]))
                        lowest = 2 * i + 2;
                if (i == lowest)
                    break;

                T temp = _list[i];
                _list[i] = _list[lowest];
                _list[lowest] = temp;
                i = lowest;
            }
        }

        public bool Any()
        {
            return _list.Any();
        }

        public T First()
        {
            return _list[0];
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}
