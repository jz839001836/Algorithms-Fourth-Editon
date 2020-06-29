using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{/// <summary>
/// 基于无序链表的包
/// </summary>
/// <typeparam name="Item"></typeparam>
    class Bag<Item>:IEnumerable<Item>
    {
        private Node<Item> first;
        private int n;
        public class Node<T>
        {
            public T item;
            public Node<T> next;
        }
        public Bag()
        {
            first = null;
            n = 0;
        }
        public bool IsEmpty()
        { return first == null; }
        public int Size()
        { return n; }
        public void Add(Item item)
        {
            Node<Item> oldfirst = first;
            first = new Node<Item>();
            first.next = oldfirst;
            first.item = item;
            n++;
        }
        public IEnumerator<Item> GetEnumerator()
        {
            if (first == null) yield break;
            Node<Item> f = first;
            do
            {
                yield return first.item;
                first = first.next;
            } while (first != null);
            first = f;     //使指针回到头结点
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
