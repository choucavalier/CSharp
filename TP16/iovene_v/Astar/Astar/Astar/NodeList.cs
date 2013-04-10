using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar
{
    class NodeList<T> : List<T> where T : Node // truc hyper cheaté qui permet de dire que la NodeList dispose de toutes les méthodes de List
                                               // et que le type générique T est un node
    {
        public new bool Contains(T node) // redéfinition de la méthode Contains
        {
            return this[node] != null;
        }
        public T this[T node] // renvoi le node si il existe dans la liste
        {
            get
            {
                int count = this.Count;
                for (int i = 0; i < count; i++)
                {
                    if (this[i].Tile == node.Tile)
                        return this[i];
                }
                return default(T);
            }
        }
        public void DichotomicInsertion(T node) // Insertion Dichotomique
        {
            int left = 0;
            int right = this.Count - 1;
            int center = 0;
            while (left <= right)
            {
                center = (left + right) / 2;
                if (node.EstimatedMovement < this[center].EstimatedMovement)
                    right = center - 1;
                else if (node.EstimatedMovement > this[center].EstimatedMovement)
                    left = center + 1;
                else
                {
                    left = center;
                    break;
                }
            }
            this.Insert(left, node);
        }
    }
}