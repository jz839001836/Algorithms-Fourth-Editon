using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于拉链法的散列表
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class SeparateChainingHashST<Key,Value>
    {
        private int N;//键值对总数
        private int M;//散列表的大小
        private SequentialSearchST<Key, Value>[] st;//存放链表对象的数组
        public SeparateChainingHashST():this(997)
        { }
        public SeparateChainingHashST(int M)
        {
            //创建M条链表
            this.M = M;
            st = new SequentialSearchST<Key, Value>[M];
            for (int i = 0; i < M; i++)
                st[i] = new SequentialSearchST<Key,Value>();
        }
        private int Hash(Key key)
        { return (key.GetHashCode() & 0x7fffffff) % M; }//除留余数法
        public Value Get(Key key)
        { return st[Hash(key)].Get(key); }
        public void Put(Key key,Value val)
        {
            if(val==null)
            {
                Delete(key);
                return;
            }
            if (N >= 10 * M) Resize(2 * M);
            int i = Hash(key);
            if (!st[i].Contains(key)) N++;
            st[i].Put(key, val);
        }
        public void Delete(Key key)
        {
            int i = Hash(key);
            if (st[i].Contains(key))
                st[i].Delete(key);
            if (N > 0 && N <= 2 * M) Resize(M / 2);
        }
        public Queue<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            Queue<Key> queue02 = new Queue<Key>();
            for(int i=0;i<M;i++)
            {
                queue02 = st[i].Keys();
                int number = queue02.Size();
                for (int j = 0; j < number; j++)
                {
                    queue.enqueue(queue02.dequeue());
                }
            }
            return queue;
        }
        private void Resize(int cap)
        {
            SeparateChainingHashST<Key, Value> temp = new SeparateChainingHashST<Key, Value>(cap);
            Queue<Key> queue = new Queue<Key>();
            Key key = default(Key);
            for (int i = 0; i < M; i++)
            {
                queue = st[i].Keys();
                int number = queue.Size();
                for (int j=0;j<number;j++)
                {
                    key = queue.dequeue();
                    temp.Put(key, st[i].Get(key));
                }
            }
            this.st = temp.st;
            this.M = temp.M;
            this.N = temp.N;
        }//动态调整散列表的大小
    }
}
