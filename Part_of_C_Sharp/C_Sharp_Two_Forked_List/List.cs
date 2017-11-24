using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Two_Forked
{
    public class Two_Forked_List<T> : ICollection<T>
    {

        public event Action<T> Added;
        public event Action<T> Removed;
        public event Action Cleared;

        public Node<T> first { get; private set; }
        public Node<T> last { get; private set; }

        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }

        public Two_Forked_List()
        {
            Count = 0;
            first = null;
            last = null;
        }

        public bool isEmpty()
        {
            return Count == 0;
        }

        public void Add(T item)  //добавление элемента
        {
            Node<T> node = new Node<T>(item);
            if (isEmpty())
                first = node;
            else
            {
                last.next = node;
                node.prev = last;
            }
            last = node;
            Count++;
            Added?.Invoke(item);
        }

        public void Expended_Add(T _item)  //расширенное добавление элемент
        {
            Console.WriteLine("Where you want add item?");
            Console.WriteLine("If you want add element to the first place, enter 0");
            Console.WriteLine("If you want add element to the last place, enter 1");
            var b = Byte.Parse(Console.ReadLine());
            var b1 = false;

            if (b == 0)
                b1 = false;
            else
                b1 = true;

            if(b1)
            {
                Node<T> node = new Node<T>(_item);
                if (isEmpty())
                    first = node;
                else
                {
                    last.next = node;
                    node.prev = last;
                }
                last = node;
            }
            else
            {
                Node<T> newNode = new Node<T>(_item);

                if (first == null)
                {
                    first = last = newNode;
                }
                else
                {
                    newNode.next = first;
                    first = newNode; 
                    newNode.next.prev = first;
                }
            }
            Count++;
            Added?.Invoke(_item);
        }

        public bool Remove(T _item)  //Удаляет первое вхождение указанного объекта
        {
            Node<T> prev = null;
            Node<T> current = first;

            while (current != null)
            {
                if (Equals(current.item, _item))
                {
                    if (prev != null)
                    {
                        prev.next = current.next;
                        if (current.next == null)
                            last = prev;
                        else
                            current.next.prev = prev;
                        Count--;
                    }
                    else
                    {
                        if (!isEmpty())
                        {
                            first = first.next;
                            Count--;
                            if (isEmpty()) last = null;
                            else first.prev = null;
                        }
                    }
                    Removed?.Invoke(_item);
                    return true;
                }
                prev = current;
                current = current.next;
            }
            return false;
        }

        public bool Insert(T _item, T _index) //вставляет элемент перед определенным элементом 
        {
            Node<T> current = first;
            while (current != null)
            {
                if (Equals(current.item, _index))
                    break;
                current = current.next;
            }
            Node<T> new_item = new Node<T>(_item);

            if (current == null) return false;
            new_item.next = current;
            new_item.prev = current.prev;

            if (current.prev != null)
                current.prev.next = new_item;
            current.prev = new_item;
            if (new_item.prev == null)
                first = new_item;
            Count++;
            Added?.Invoke(_item);
            return true;
        }

        public bool Delete() //Удаляет первый или последний элемент
        {
            Console.WriteLine("Where you want delete item?");
            Console.WriteLine("If you want delete first element, enter 0");
            Console.WriteLine("If you want delete last element, enter 1");
            var b = Byte.Parse(Console.ReadLine());
            var b1 = false;

            if (b == 0)
                b1 = false;
            else
                b1 = true;

            if (!b1)
            {
                if (first == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    Node<T> temp = first;
                    if (first.next != null)
                    {
                        first.next.prev = null;
                    }
                    first = first.next;
                    Count--;
                    return true;
                }

            }
            else
            {
                if (last == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    Node<T> temp = last;
                    if (last.prev != null)
                    {
                        last.prev.next = null;
                    }
                    last = last.prev;
                    Count--;
                    return true;
                }
            }
        }

        public void CopyTo(T[] Array, int arrayIndex)  //Копирует элементы списка в массив Array, начиная с указанного индекса массива Array.
        {
            Node<T> current = first;
            while (current != null)
            {
                Array[arrayIndex++] = current.item;
                current = current.next;
            }
        }

        public bool Contains(T _item)   //Определяет, содержит ли список указанное значение
        {
            Node<T> current = first;
            while (current != null)
            {
                if (Equals(current.item, _item))
                    break;
                current = current.next;
            }
            if (current != null)
                return true;
            else
                return false;
        }

        public void Clear()  //Удаляет все элементы
        {
            first = null;
            last = null;
            Count = 0;
            Cleared?.Invoke();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;
            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
