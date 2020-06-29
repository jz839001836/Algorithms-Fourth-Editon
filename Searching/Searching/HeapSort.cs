using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 堆排序
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class HeapSort<Item>where Item:IComparable<Item>
    {
        public static void Sort(Item[] a)
        {
            int N = a.Length;
            for (int k = N / 2; k >= 1; k--)
                Sink(a, k, N);
            while(N>1)
            {
                Exch(a, 1, N--);
                Sink(a, 1, N);
            }
        }
        private static void Sink(Item[] a,int k,int N)
        {
            while(2*k<=N)
            {
                int j = 2 * k;
                if (j < N && Less(a, j, j + 1)) j++;//寻找根节点左右两端子结点的最大值
                if (!Less(a, k, j)) break;
                Exch(a, k, j);
                k = j;
            }
        }
        private static bool Less(Item[] a,int i,int j)
        { return a[i - 1].CompareTo(a[j - 1]) < 0; }
        private static void Exch(Item[] a,int i,int j)
        {
            Item t = a[i - 1];
            a[i - 1] = a[j - 1];
            a[j - 1] = t;
        }
    }
}
