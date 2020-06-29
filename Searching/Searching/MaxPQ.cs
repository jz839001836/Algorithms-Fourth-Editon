using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 最大值优先的优先队列
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class MaxPQ<Item>where Item:IComparable<Item>
    {
        private Item[] pq;//基于堆的完全二叉树
        private int N = 0;
        public MaxPQ(int maxN)
        {
            pq = new Item[maxN + 1];
        }
        public bool IsEmpty()
        { return N == 0; }
        public int Size()
        { return N; }
        private bool Less(int i,int j)
        { return pq[i].CompareTo(pq[j]) < 0; }
        private void Exch(int i,int j)
        {
            Item t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }
        private void Swim(int k)
        {
            while(k>1&&Less(k/2,k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }//由下至上的堆有序化（上浮）的实现
        private void Sink(int k)
        {
            while(2*k<N)
            {
                int j = 2 * k;
                if (j < N && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }//有上至下的堆有序化（下沉）的实现
        public void Insert(Item v)
        {
            pq[++N] = v;
            Swim(N);
        }
        public Item DelMax()
        {
            Item max = pq[1];    //从根节点得到最大的元素
            Exch(1, N--);        //将其和最后一个结点交换
            pq[N + 1] = default(Item);//防止对象游离
            Sink(1);  //恢复堆的有序性
            return max;
        }
    }
}
