using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Two_Forked
{
    public class Node<T>
    {
        public T item; //значение внутри ячейки списка
        public Node<T> next { get; set; }
        public Node<T> prev { get; set; }

        public Node(T _item)
        {
            this.item = _item;
        }
    }
}
