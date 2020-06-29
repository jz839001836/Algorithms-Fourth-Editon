using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于链表实现的先进先出队列
    /// </summary>
    /// <typeparam name="Item">数据类型</typeparam>
    class Queue<Item>:IEnumerable<Item>
    {
        private Node<Item> first;
        private Node<Item> last;
        private int n;

        private class Node<i>
        {
            public i item;
            public Node<i> next;
        }
        public Queue()
        {
            first = null;
            last = null;
            n = 0;
        }
        public bool IsEmpty()
        { return first == null; }
        public int Size()
        { return n; }
        public void enqueue(Item item)//向表尾添加元素
        {
            Node<Item> oldlast = last;
            last = new Node<Item>();
            last.item = item;
            last.next = null;
            if (IsEmpty()) first = last;
            else oldlast.next = last;
            n++;
        }
        public Item dequeue()//从表头弹出元素，并删去表头
        {
            Item item = first.item;
            first = first.next;
            if (IsEmpty()) last = null;
            n--;
            return item;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            Node<Item> d = first;//存储头结点
            do
            {
                yield return first.item;
                first = first.next;
            } while (first != null);
            first = d;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
