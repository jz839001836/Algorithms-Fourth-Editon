using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    /// <summary>
    /// 归并排序
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class MergeSort<Item>where Item:IComparable<Item>
    {
        private static Item[] aux;
        public static void Merge(Item[] a,int lo,int mid,int hi)
        {
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (Less(aux[j], aux[i]))
                    a[k] = aux[j++];
                else
                    a[k] = aux[i++];
            }
        }//原地抽象归并
        public static void Sort(Item[] a)
        {
            aux = new Item[a.Length];
            Sort(a, 0, a.Length - 1);
        }
        private static void Sort(Item[] a,int lo,int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }
        private static void Exch(Item[] a, int i, int j)
        {
            Item t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
        private static bool Less(Item v, Item w)
        {
            return v.CompareTo(w) < 0;
        }
        public static void Show(Item[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
        public static bool IsSorted(Item[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                    return false;
            }
            return true;
        }
    }
}
