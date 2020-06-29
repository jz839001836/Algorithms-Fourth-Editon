using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最小值优先的优先队列
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    class MinPQ<Key>where Key:IComparable<Key>
    {
        private Key[] pq;
        private int N;
        public MinPQ(int minN)
        {
            pq = new Key[minN + 1];
            N = 0;
        }
        public MinPQ() : this(1)
        { }
        public bool IsEmpty()
        { return N == 0; }
        public int Size()
        { return N; }
        public Key Min()
        {
            if (IsEmpty())
                throw new Exception("优先队列为空");
            return pq[1];
        }
        private void Resize(int capacity)
        {
            Key[] temp = new Key[capacity];
            for (int i = 1; i <= N; i++)
                temp[i] = pq[i];
            pq = temp;
        }
        public void Insert(Key x)
        {
            if (N == pq.Length - 1) Resize(2 * pq.Length);
            pq[++N] = x;
            Swim(N);
        }
        public Key DelMin()
        {
            if (IsEmpty())
                throw new Exception("优先队列为空");
            Key min = pq[1];
            Exch(1, N--);
            Sink(1);
            pq[N + 1] = default(Key);
            if ((N > 0) && (N == (pq.Length - 1) / 4)) Resize(pq.Length / 2);
            return min;
        }
        private void Swim(int k)
        {
            while(k>1&&Greater(k/2,k))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }//上浮实现
        private void Sink(int k)
        {
            while(2*k<=N)
            {
                int j = 2 * k;
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }//下沉实现
        private bool Greater(int i,int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }
        private void Exch(int i,int j)
        {
            Key swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }
    }
}
