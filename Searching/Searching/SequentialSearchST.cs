using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 顺序查找（基于无序链表）
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class SequentialSearchST<Key,Value>
    {
        private int n = 0;
        private Node first;
        private class Node
        {
            public Key key;
            public Value val;
            public Node next;
            public Node(Key key,Value val,Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }//链表实现
        public Value Get(Key key)
        {
            for (Node x = first; x != null; x = x.next)
                if (key.Equals(x.key))
                    return x.val;
            return default(Value);
        }
        public void Put(Key key,Value val)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.val = val;
                    return;
                }
            }
            first = new Node(key, val, first);
            n++;
        }
        public int Size()
        {
            return n;
        }
        public void Delete(Key key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if(key.Equals(x.key))
                    x = x.next;
            }
        }
        public bool Contains(Key key)
        {
            return Get(key) != null;
        }
        public Queue<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            for (Node x = first; x != null; x = x.next)
                queue.enqueue(x.key);
            return queue;
        }
    }
}
