using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class MSD
    {
        private static int R = 256;         //基数
        private static readonly int M = 15; //小数组的切换阈值
        private static String[] aux;        //数据分类的辅助数组
        private static int CharAt(String s,int d)
        {
            if (d < s.Length)
                return s[d];
            else
                return -1;
        }
        private static void Sort(String[] a)
        {
            int N = a.Length;
            aux = new string[N];
            Sort(a, 0, N - 1, 0);
        }
        private static void Sort(String[] a, int lo,int hi,int d) //以第d个字符为键将a[lo]至a[hi]排序
        {
            if(hi<=lo+M)
            {
                InsertionSort(a, lo, hi, d);
                return;
            }
            int[] count = new int[R + 2];     
            for (int i = lo; i <= hi; i++)    //计算频率
                count[CharAt(a[i], d) + 2]++;
            for (int r = 0; r < R + 1; r++)   //将频率转换为索引
                count[r + 1] += count[r];
            for (int i = lo; i <= hi; i++)    //数据分类
                aux[count[CharAt(a[i], d) + 1]++] = a[i];
            for (int i = lo; i <= hi; i++)    //回写
                a[i] = aux[i - lo];
            //递归的以每个字符为键进行排序
            for (int r = 0; r < R; r++)
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }

        private static void InsertionSort(String[] a,int lo,int hi,int d)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && Less(a[j], a[j - 1], d); j--)
                    Exch(a, j, j - 1);
        }
        private static bool Less(String v,String w,int d)
        {
            return v.Substring(d).CompareTo(w.Substring(d)) < 0;
        }
        private static void Exch(String[] a, int i, int j)
        {
            string t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
