using System;

namespace MathieuAUnChat
{
    class MyMagicArray<T> where T : IComparable
    {
        T[] _table;
        int _length;

        public delegate bool PredicateDelegate(T elt);

        public MyMagicArray()
        {
            _length = 10;
            _table = new T[10];
        }

        public void Insert(T elt)
        {
            int i = 0;
            while (i < _table.Length && _table[i].CompareTo(default(T)) != 0)
                i++;
            if (i == _table.Length)
            {
                T[] ntable = new T[_length*2];
                for (int j = 0; j < _table.Length; j++)
                    ntable[j] = _table[j];
                _table = ntable;
            }
            _table[i] = elt;
            _length++;
        }

        public bool Delete(T elt)
        {
            int i = 0;
            while (i < _table.Length && _table[i].CompareTo(elt) != 0)
                i++;
            if (i == _table.Length)
                return false;
            _table[i] = default(T);
            for (int j = i; j < _table.Length - 1; j++)
                _table[j] = _table[j + 1];
            _table[_table.Length - 1] = default(T);
            _length--;
            return true;
        }

        public T At(int i)
        {
            if (i < 0 || i >= _table.Length)
                throw new Exception("Index out of range");

            return _table[i];
        }

        public delegate T MapDelegate(T elt);

        public void Map(MapDelegate funct)
        {
            for (int i = 0; i < _table.Length; i++)
                _table[i] = funct(_table[i]);
        }

        public void Print(PredicateDelegate predicate)
        {
            foreach (var t in _table)
            {
                Console.ForegroundColor = predicate(t) ? ConsoleColor.Green : ConsoleColor.White;
                Console.Write(t + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void Swap(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _table.Length || y >= _table.Length)
                return;
            T aux = _table[x];
            _table[x] = _table[y];
            _table[y] = aux;
        }

        public int QuicksortPartition(int l, int r, int p)
        {
            Swap(p, r);
            p = r;
            int s = l;
            for (int i = l; i < r; i++)
                if (_table[i].CompareTo(_table[p]) < 0)
                {
                    Swap(i, s);
                    s++;
                }
            Swap(s, r);
            return s;
        }
    
        public void Quicksort(int l, int r)
        {
            if (l < r)
            {
                Random ran = new Random();
                int p = QuicksortPartition(l, r, ran.Next(l, r + 1));
                Quicksort(l, p - 1);
                Quicksort(p + 1, r);
            }
        }

        /////////////////////////////////////////////////////
        // BONUS
        /////////////////////////////////////////////////////

        /// <summary>
        /// Insert un element a sa place dans un tableau ordonné de manière croissante
        /// </summary>
        /// <param name="elt">Element à insérer</param>
        public void InsertOrdered(T elt)
        {
            int i = 0;
            while (i < _table.Length && elt.CompareTo(_table[i]) == 1 && _table[i].CompareTo(default(T)) != 0)
                i++;
            if (_length + 1 > _table.Length)
            {
                T[] ntable = new T[_length * 2];
                for (int j = 0; j < _table.Length; j++)
                    ntable[j] = _table[j];
                _table = ntable;
            }
            for (int j = _table.Length - 1; j > i; j--)
                _table[j] = _table[j - 1];
            _table[i] = elt;
            _length++;
        }

        /// <summary>
        /// Renvoit un nouveau tableau contenant les éléments qui respectent le predicat envoyé en paramètre.
        /// </summary>
        /// <param name="p">Prédicat que les éléments que l'on souhaite obtenir doivent valider</param>
        /// <returns></returns>
        public MyMagicArray<T> Select(Predicate<T> p)
        {
            MyMagicArray<T> r = new MyMagicArray<T>();
            for (int i = 0; i < _length; i++)
                if (p(_table[i]))
                    r.InsertOrdered(_table[i]);
            return r;
        }
    }
}
