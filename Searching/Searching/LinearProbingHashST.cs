using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 基于线性探测的符号表
    /// </summary>
    /// <typeparam name="Key">键</typeparam>
    /// <typeparam name="Value">值</typeparam>
    class LinearProbingHashST<Key, Value>
    {
        private int N;//符号表中的键值对的总数
        private int M = 16;//线性探测表的大小
        private Key[] keys;//键
        private Value[] vals;//值
        public LinearProbingHashST(int cap)
        {
            M = cap;
            N = 0;
            keys = new Key[M];
            vals = new Value[M];
        }
        private int Hash(Key key)
        { return (key.GetHashCode() & 0x7fffffff) % M; }
        public void Delete(Key key)
        {
            if (!Contains(key)) return;
            int i = Hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % M;
            keys[i] = default(Key);
            vals[i] = default(Value);
            i = (i + 1) % M;
            while (keys[i] != null)
            {
                Key keyToRedo = keys[i];
                Value valToRedo = vals[i];
                keys[i] = default(Key);
                vals[i] = default(Value);
                N--;
                Put(keyToRedo, valToRedo);
                i = (i + 1) % M;
            }
            N--;
            if (N > 0 && N == M / 8)
                Resize(M / 2);
        }
        public void Put(Key key, Value val)
        {
            if (N >= M / 2) Resize(2 * M);
            int i;
            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    vals[i] = val;
                    return;
                }
            }
            keys[i] = key;
            vals[i] = val;
            N++;
        }//若当前位置已有数值，则索引指向下一个位置，直到键值对插入完成
        private void Resize(int cap)
        {
            LinearProbingHashST<Key, Value> t = new LinearProbingHashST<Key, Value>(cap);
            for (int i = 0; i < M; i++)
                if (keys[i] != null)
                    t.Put(keys[i], vals[i]);
            keys = t.keys;
            vals = t.vals;
            M = t.M;
        }
        
        public bool Contains(Key key)
        { return Get(key) != null; }
        public Value Get(Key key)
        {
            for (int i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                    return vals[i];
            }
            return default(Value);
        }
        public Queue<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            for (int i = 0; i < M; i++)
            {
                if (keys[i] != null)
                    queue.enqueue(keys[i]);
            }
            return queue;
        }
        public int Size()
        { return N; }
    }
}
