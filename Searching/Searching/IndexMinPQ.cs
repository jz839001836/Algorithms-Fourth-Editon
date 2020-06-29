using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最小值优先的索引优先队列
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    class IndexMinPQ<Key>where Key:IComparable<Key>
    {
        private int N;      //PQ中的元素数量
        private int[] pq;   //索引二叉堆，由1开始，保存key的索引k
        private int[] qp;   //逆序：qp[pq[i]]=pq[qp[i]]=i，保存元素的数量
        private Key[] keys; //有优先级之分的元素
        public IndexMinPQ(int maxN)
        {
            keys = new Key[maxN + 1];
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];
            for (int i = 0; i <= maxN; i++) qp[i] = -1;
        }
        public bool IsEmpty()
        { return N == 0; }
        public bool Contains(int k)
        { return qp[k] != -1; }
        public void Insert(int k,Key key)
        {
            N++;
            qp[k] = N;   //保存索引K对应的元素的排列位置
            pq[N] = k;   //存放Key的索引k
            keys[k] = key;
            Swim(N);
        }//插入一个元素，将它和索引k相管关联
        public int DelMin()
        {
            int indexOfMin = pq[1];
            Exch(1, N--);
            Sink(1);
            keys[pq[N + 1]] = default(Key);
            qp[pq[N + 1]] = -1;
            return indexOfMin;
        }//删除并返回最小值的索引
        public Key Min()
        { return keys[pq[1]]; }
        private bool Greater(int i,int j)
        { return keys[pq[i]].CompareTo(keys[pq[j]]) > 0; }
        private void Exch(int i,int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
        private void Swim(int k)
        {
            while(k>1&&Greater(k/2,k))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }
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
        }
        public int MinIndex()
        { return pq[1]; }
        public void Change(int k,Key key)
        {
            keys[k] = key;
            Swim(qp[k]);
            Sink(qp[k]);
        }//将索引为k的元素设为key
        public void Delete(int k)
        {
            int index = qp[k];
            Exch(index, N--);
            Swim(index);
            Sink(index);
            keys[k] = default(Key);
            qp[k] = -1;
        }//删去索引k及其相关联的元素
    }
}
