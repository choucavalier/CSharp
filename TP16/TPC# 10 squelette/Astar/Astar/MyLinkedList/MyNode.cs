using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar.MyLinkedList
{
    class MyNode<T> where T : IComparable
    {
        T data;
        MyNode<T> nextNode = null;

        // FIXME : getter sur data et nextNode        
        public T Data
        { get { return default(T); } } 
        public MyNode<T> NextNode
        { get { return null; } }

        public MyNode(T data)
        {
            // FIXME
        }
    }
}
