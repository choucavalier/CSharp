using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar.MyLinkedList
{
    class MyLinkedList<T> where T : IComparable // IComparable permet d'effectuer des comaparaisons sur des types génériques T
    {
        private MyNode<T> head = null;
        private int size = 0;

        // FIXME : getter sur size et head    
        public int Size
        { get { return 0; } }

        public MyNode<T> Head
        { get { return null; } }
        



        // Ne pas oublier de mettre la size à jour

        public void AddFirst(T node) // ajout en tete
        {
            // FIXME
        }

        public bool IsExist(T node) // existence du noeud dans la liste
        {
            // FIXME

            return false;
        }

        public void AddEnd(T node) // ajout en queue
        {
            // FIXME
        }

        public void RemoveFirst(T node) // suppression de la tete de la liste
        {
            // FIXME
        }

        public void Remove(T node) // suppression d'un noeud dans la liste
        {
            // FIXME
        }

        public void Clear() // destruction de la liste
        {
            // FIXME
        }

        public void DisplayNodes() // affichage de la liste
        {
            // FIXME
        }
    }
}
