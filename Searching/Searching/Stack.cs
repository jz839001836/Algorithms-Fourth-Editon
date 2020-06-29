using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于链表的先进后出的栈
    /// </summary>
    /// <typeparam name="Item">数据类型</typeparam>
    class Stack<Item>:IEnumerable<Item>
    {
        private Node<Item> first;
        private int n;
        public class Node<T>
        {
            public T item;
            public Node<T> next;
        }
        public bool IsEmpty()
        { return first == null; }
        public int Size()
        { return n; }
        public void Push(Item item)
        {
            Node<Item> oldfirst = first;
            first = new Node<Item>();
            first.next = oldfirst;
            first.item = item;
            n++;
        }//从表头入栈
        public Item Pop()
        {
            Item item = first.item;
            first = first.next;
            n--;
            return item;
        }//从表头出栈
        public void DeleteLast()
        {
            Node<Item> del = new Node<Item>();
            del = first;
            while(del.next.next!=null)
            {
                del = del.next;
            }
            del.next = null;
        }
        public IEnumerator<Item> GetEnumerator()
        {
            if (first == null)
                yield break;
            Node<Item> f = first;
            do
            {
                yield return first.item;
                first = first.next;
            } while (first != null);
            first = f;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
